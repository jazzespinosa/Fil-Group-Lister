using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Principal;
using System.Windows.Forms;

namespace Fil_Group_Lister
{
    public partial class MainWindow : Form
    {
        private string currentFindValue { get; set; } = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            cbxFilterSecGroups.Text = "ALL Groups";
            cbxInheritance.Text = "ALL";
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string folderPath = tboxDirectory.Text.Trim();
            if (folderPath.EndsWith("\\")) folderPath = folderPath.Substring(0, folderPath.Length - 1);

            if (folderPath.Length <= 0)
            {
                MessageBox.Show("Directory field empty.");
                tboxDirectory.Clear();
                return;
            }

            bool ifDirExists = new DirectoryInfo(tboxDirectory.Text).Exists;
            if (ifDirExists == false)
            {
                MessageBox.Show("Folder path does not exist.");
                treeViewDirectory.Nodes.Clear();
                return;
            }

            currentFindValue = folderPath;
            createDataTable(folderPath);
        }

        void createDataTable(string folderPath)
        {
            if (folderPath.Length <= 0) return;

            int count = folderPath.Count(x => x == '\\');

            var dt = new DataTable();
            dt.Columns.Add("FolderName", typeof(string));
            dt.Columns.Add("Path", typeof(string));
            dt.Columns.Add("Permission", typeof(string));
            dt.Columns.Add("AccessType", typeof(string));
            dt.Columns.Add("ifInherited", typeof(bool));
            dt.Columns.Add("ifFilGroup", typeof(bool));

            do
            {
                string lastFolder = folderPath.Substring(folderPath.LastIndexOf("\\") + 1); //get last folder name

                var dInfo = new DirectoryInfo(folderPath);
                var dSecurity = dInfo.GetAccessControl(AccessControlSections.Access);

                foreach (FileSystemAccessRule rule in dSecurity.GetAccessRules(true, true, typeof(NTAccount)))
                {
                    string permName = rule.IdentityReference.Value;
                    string permNameFinal = permName;
                    try
                    {
                        SecurityIdentifier securityIdentifier = new SecurityIdentifier(permName);
                        permNameFinal = securityIdentifier.Translate(typeof(NTAccount)).Value;
                    }
                    catch { }

                    string permAccessType = rule.FileSystemRights.ToString();
                    int countpermAccessType = permAccessType.Count(x => x == ',');
                    bool permIfInherited = rule.IsInherited ? true : false;

                    if (countpermAccessType > 0)
                    {
                        var finalPermAccessType = permAccessType.Substring(permAccessType.LastIndexOf(",") + 1);
                        permAccessType = permAccessType.Substring(0, permAccessType.Length - (finalPermAccessType.Length + 1));
                    }

                    permName = permName.Substring(permName.LastIndexOf("\\") + 1);

                    bool ifFilGroup = false;

                    if (permName.Substring(0, 3).ToLower() == "fil")
                    {
                        ifFilGroup = true;
                    }
                    dt.Rows.Add(lastFolder, folderPath, permName, permAccessType, permIfInherited, ifFilGroup);
                }

                folderPath = folderPath.Substring(0, folderPath.Length - (lastFolder.Length + 1)); //get next folder path

                count--;
            } while (count > 0);

            filterDataTable(dt);
        }

        private void filterDataTable(DataTable dt)
        {
            string dtColumnName;
            bool dtRowValue;
            DataTable dtInitial = dt.AsEnumerable()
                .GroupBy(row => new { FolderName = row.Field<string>("FolderName"), Path = row.Field<string>("Path") })
                .Select(g => g.First())
                .CopyToDataTable();

            if (cbxFilterSecGroups.Text == "File Groups Only")
            {
                dtColumnName = "ifFilGroup";
                dtRowValue = true;

                if (countDTRows(dt, dtColumnName, dtRowValue) <= 0)
                {
                    MessageBox.Show("No groups to display.");
                    return;
                }

                DataTable dtFilterSecGroups = dt.AsEnumerable()
                    .Where(row => row.Field<bool>("ifFilGroup") == true)
                    .CopyToDataTable();

                dt = dtFilterSecGroups;
            }

            if (cbxInheritance.Text == "Inherited Only")
            {
                dtColumnName = "ifInherited";
                dtRowValue = true;

                if (countDTRows(dt, dtColumnName, dtRowValue) <= 0)
                {
                    MessageBox.Show("No groups to display.");
                    return;
                }

                dt = dtIfInherited(dt, true);
            }
            else if (cbxInheritance.Text == "Not Inherited Only")
            {
                dtColumnName = "ifInherited";
                dtRowValue = false;

                if (countDTRows(dt, dtColumnName, dtRowValue) <= 0)
                {
                    MessageBox.Show("No groups to display.");
                    return;
                }

                dt = dtIfInherited(dt, false);
            }
            displayTreeView(dt, dtInitial);
        }

        private DataTable dtIfInherited(DataTable dt, bool ifInherited)
        {
            DataTable dataTable = dt.AsEnumerable()
                    .Where(row => row.Field<bool>("ifInherited") == ifInherited)
                    .CopyToDataTable();

            return dataTable;
        }

        private int countDTRows(DataTable dt, string dtColumnName, bool dtRowValue)
        {
            return dt.AsEnumerable().Count(row => row.Field<bool>(dtColumnName) == dtRowValue);
        }

        private int countRows(DataTable dt, string dtColumnName1, string dtRowValue1, string dtColumnName2, string dtRowValue2)
        {
            return dt.AsEnumerable().Count(row => row.Field<string>(dtColumnName1) == dtRowValue1
                                               && row.Field<string>(dtColumnName2) == dtRowValue2);
        }

        private void displayTreeView(DataTable dt, DataTable dtInitial)
        {
            int i = 0;
            treeViewDirectory.Nodes.Clear();

            while (i < dtInitial.Rows.Count)
            {
                DataRow rowInitial = dtInitial.Rows[i];

                string folderName = rowInitial.Field<string>(0);
                string folderPath = rowInitial.Field<string>(1);
                string dispFolderName = $"{folderName} ( {folderPath} )";

                TreeNode folderNode = treeViewDirectory.Nodes.Add(dispFolderName);
                folderNode.NodeFont = new Font(treeViewDirectory.Font.FontFamily, 11, FontStyle.Bold);
                folderNode.Text = dispFolderName;

                foreach (DataRow row in dt.Rows)
                {
                    if (row[0] == folderName && row[1] == folderPath)
                    {
                        string folderPermission = row.Field<string>(2);
                        string accessType = row.Field<string>(3);
                        string ifInherited = row.Field<bool>(4) ? "Inherited" : "Not Inherited";
                        if (accessType != null)
                        {
                            folderNode.Nodes.Add($"{folderPermission} | ( {accessType}, {ifInherited} )");
                        }
                    }
                }
                i++;
            }

            treeViewDirectory.ExpandAll();
            //treeViewDirectory.Nodes[0].EnsureVisible();
            treeViewDirectory.SelectedNode = treeViewDirectory.Nodes[0];
        }

        private void treeViewDirectory_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = treeViewDirectory.SelectedNode;
            if (node.Nodes.Count == 0)
            {
                string selectedNode = treeViewDirectory.SelectedNode.Text;
                int index = selectedNode.IndexOf('|');
                if (index > 0)
                {
                    selectedNode = selectedNode.Substring(0, index);
                    selectedNode = selectedNode.Trim();
                }
                Clipboard.SetText(selectedNode);
            }

        }

        private void cbxFilterSecGroups_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeViewDirectory.Nodes.Clear();
            createDataTable(currentFindValue);
        }

        private void tboxDirectory_SizeChanged(object sender, EventArgs e)
        {
            string tbox = tboxDirectory.Text;
            tboxDirectory.Clear();
            tboxDirectory.Text = tbox;
            tboxDirectory.Focus();
            tboxDirectory.SelectAll();
        }

        private void cbxInheritance_SelectedIndexChanged(object sender, EventArgs e)
        {
            treeViewDirectory.Nodes.Clear();
            createDataTable(currentFindValue);
        }

    }
}
