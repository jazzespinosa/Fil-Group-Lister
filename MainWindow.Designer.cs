using System.Drawing;
using System.Windows.Forms;

namespace Fil_Group_Lister
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.labelDirectory = new System.Windows.Forms.Label();
            this.tboxDirectory = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.treeViewDirectory = new System.Windows.Forms.TreeView();
            this.labelSecGroups = new System.Windows.Forms.Label();
            this.cbxFilterSecGroups = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbxInheritance = new System.Windows.Forms.ComboBox();
            this.labelInheritance = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelDirectory
            // 
            this.labelDirectory.AutoSize = true;
            this.labelDirectory.Location = new System.Drawing.Point(7, 58);
            this.labelDirectory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDirectory.Name = "labelDirectory";
            this.labelDirectory.Size = new System.Drawing.Size(59, 17);
            this.labelDirectory.TabIndex = 0;
            this.labelDirectory.Text = "Directory";
            // 
            // tboxDirectory
            // 
            this.tboxDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tboxDirectory.BackColor = System.Drawing.Color.White;
            this.tboxDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tboxDirectory.Location = new System.Drawing.Point(66, 54);
            this.tboxDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.tboxDirectory.Name = "tboxDirectory";
            this.tboxDirectory.Size = new System.Drawing.Size(259, 23);
            this.tboxDirectory.TabIndex = 1;
            this.tboxDirectory.SizeChanged += new System.EventHandler(this.tboxDirectory_SizeChanged);
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(331, 52);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 26);
            this.btnFind.TabIndex = 2;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // treeViewDirectory
            // 
            this.treeViewDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeViewDirectory.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.treeViewDirectory.Location = new System.Drawing.Point(7, 84);
            this.treeViewDirectory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.treeViewDirectory.Name = "treeViewDirectory";
            this.treeViewDirectory.Size = new System.Drawing.Size(399, 315);
            this.treeViewDirectory.TabIndex = 3;
            this.treeViewDirectory.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeViewDirectory_NodeMouseDoubleClick);
            // 
            // labelSecGroups
            // 
            this.labelSecGroups.AutoSize = true;
            this.labelSecGroups.Location = new System.Drawing.Point(7, 20);
            this.labelSecGroups.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSecGroups.Name = "labelSecGroups";
            this.labelSecGroups.Size = new System.Drawing.Size(74, 17);
            this.labelSecGroups.TabIndex = 7;
            this.labelSecGroups.Text = "Sec Groups";
            // 
            // cbxFilterSecGroups
            // 
            this.cbxFilterSecGroups.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxFilterSecGroups.FormattingEnabled = true;
            this.cbxFilterSecGroups.Items.AddRange(new object[] {
            "ALL Groups",
            "File Groups Only"});
            this.cbxFilterSecGroups.Location = new System.Drawing.Point(80, 16);
            this.cbxFilterSecGroups.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxFilterSecGroups.Name = "cbxFilterSecGroups";
            this.cbxFilterSecGroups.Size = new System.Drawing.Size(121, 25);
            this.cbxFilterSecGroups.TabIndex = 8;
            this.cbxFilterSecGroups.SelectedIndexChanged += new System.EventHandler(this.cbxFilterSecGroups_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbxInheritance);
            this.groupBox1.Controls.Add(this.labelInheritance);
            this.groupBox1.Controls.Add(this.cbxFilterSecGroups);
            this.groupBox1.Controls.Add(this.labelSecGroups);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(414, 49);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // cbxInheritance
            // 
            this.cbxInheritance.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxInheritance.FormattingEnabled = true;
            this.cbxInheritance.Items.AddRange(new object[] {
            "ALL",
            "Inherited Only",
            "Not Inherited Only"});
            this.cbxInheritance.Location = new System.Drawing.Point(275, 16);
            this.cbxInheritance.Name = "cbxInheritance";
            this.cbxInheritance.Size = new System.Drawing.Size(131, 25);
            this.cbxInheritance.TabIndex = 10;
            this.cbxInheritance.SelectedIndexChanged += new System.EventHandler(this.cbxInheritance_SelectedIndexChanged);
            // 
            // labelInheritance
            // 
            this.labelInheritance.AutoSize = true;
            this.labelInheritance.Location = new System.Drawing.Point(203, 20);
            this.labelInheritance.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelInheritance.Name = "labelInheritance";
            this.labelInheritance.Size = new System.Drawing.Size(72, 17);
            this.labelInheritance.TabIndex = 9;
            this.labelInheritance.Text = "Inheritance";
            // 
            // MainWindow
            // 
            this.AcceptButton = this.btnFind;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(190)))), ((int)(((byte)(190)))));
            this.ClientSize = new System.Drawing.Size(414, 411);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.treeViewDirectory);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.tboxDirectory);
            this.Controls.Add(this.labelDirectory);
            this.Font = new System.Drawing.Font("Roboto", 9.75F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MinimumSize = new System.Drawing.Size(430, 450);
            this.Name = "MainWindow";
            this.Text = "Fil Group Lister";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelDirectory;
        private System.Windows.Forms.TextBox tboxDirectory;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TreeView treeViewDirectory;
        private System.Windows.Forms.Label labelSecGroups;
        private System.Windows.Forms.ComboBox cbxFilterSecGroups;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbxInheritance;
        private System.Windows.Forms.Label labelInheritance;
    }
}
