namespace TextEditor
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.rtb_MainEditor = new System.Windows.Forms.RichTextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configurationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.conToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileStorageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hddToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btXmlType = new System.Windows.Forms.Button();
            this.btJsonType = new System.Windows.Forms.Button();
            this.btTxtType = new System.Windows.Forms.Button();
            this.lbInf = new System.Windows.Forms.Label();
            this.lbInfo = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtb_MainEditor
            // 
            this.rtb_MainEditor.Location = new System.Drawing.Point(0, 27);
            this.rtb_MainEditor.Margin = new System.Windows.Forms.Padding(5);
            this.rtb_MainEditor.Name = "rtb_MainEditor";
            this.rtb_MainEditor.Size = new System.Drawing.Size(1016, 399);
            this.rtb_MainEditor.TabIndex = 2;
            this.rtb_MainEditor.Text = "";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.configurationToolStripMenuItem,
            this.fileStorageToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1099, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // configurationToolStripMenuItem
            // 
            this.configurationToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.conToolStripMenuItem});
            this.configurationToolStripMenuItem.Name = "configurationToolStripMenuItem";
            this.configurationToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.configurationToolStripMenuItem.Text = "Options";
            // 
            // conToolStripMenuItem
            // 
            this.conToolStripMenuItem.Name = "conToolStripMenuItem";
            this.conToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.conToolStripMenuItem.Text = "Settings";
            this.conToolStripMenuItem.Click += new System.EventHandler(this.conToolStripMenuItem_Click);
            // 
            // fileStorageToolStripMenuItem
            // 
            this.fileStorageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hddToolStripMenuItem,
            this.databaseToolStripMenuItem});
            this.fileStorageToolStripMenuItem.Name = "fileStorageToolStripMenuItem";
            this.fileStorageToolStripMenuItem.Size = new System.Drawing.Size(80, 20);
            this.fileStorageToolStripMenuItem.Text = "File Storage";
            // 
            // hddToolStripMenuItem
            // 
            this.hddToolStripMenuItem.Checked = true;
            this.hddToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hddToolStripMenuItem.Name = "hddToolStripMenuItem";
            this.hddToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.hddToolStripMenuItem.Text = "HDD";
            this.hddToolStripMenuItem.Click += new System.EventHandler(this.hddToolStripMenuItem_Click);
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.databaseToolStripMenuItem.Text = "Database";
            this.databaseToolStripMenuItem.Click += new System.EventHandler(this.databaseToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // btXmlType
            // 
            this.btXmlType.Location = new System.Drawing.Point(1024, 27);
            this.btXmlType.Name = "btXmlType";
            this.btXmlType.Size = new System.Drawing.Size(75, 23);
            this.btXmlType.TabIndex = 4;
            this.btXmlType.Text = "XML";
            this.btXmlType.UseVisualStyleBackColor = true;
            this.btXmlType.Click += new System.EventHandler(this.btXmlType_Click);
            // 
            // btJsonType
            // 
            this.btJsonType.Location = new System.Drawing.Point(1024, 56);
            this.btJsonType.Name = "btJsonType";
            this.btJsonType.Size = new System.Drawing.Size(75, 23);
            this.btJsonType.TabIndex = 5;
            this.btJsonType.Text = "JSON";
            this.btJsonType.UseVisualStyleBackColor = true;
            this.btJsonType.Click += new System.EventHandler(this.btJsonType_Click);
            // 
            // btTxtType
            // 
            this.btTxtType.Location = new System.Drawing.Point(1024, 85);
            this.btTxtType.Name = "btTxtType";
            this.btTxtType.Size = new System.Drawing.Size(75, 23);
            this.btTxtType.TabIndex = 6;
            this.btTxtType.Text = "TXT";
            this.btTxtType.UseVisualStyleBackColor = true;
            this.btTxtType.Click += new System.EventHandler(this.btTxtType_Click);
            // 
            // lbInf
            // 
            this.lbInf.AutoSize = true;
            this.lbInf.Location = new System.Drawing.Point(12, 431);
            this.lbInf.Name = "lbInf";
            this.lbInf.Size = new System.Drawing.Size(28, 13);
            this.lbInf.TabIndex = 7;
            this.lbInf.Text = "Info:";
            // 
            // lbInfo
            // 
            this.lbInfo.AutoSize = true;
            this.lbInfo.Enabled = false;
            this.lbInfo.Location = new System.Drawing.Point(47, 431);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(0, 13);
            this.lbInfo.TabIndex = 8;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 451);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.lbInf);
            this.Controls.Add(this.btTxtType);
            this.Controls.Add(this.btJsonType);
            this.Controls.Add(this.btXmlType);
            this.Controls.Add(this.rtb_MainEditor);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Untitled - Text Editor";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox rtb_MainEditor;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configurationToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem conToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fileStorageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem hddToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Button btXmlType;
        private System.Windows.Forms.Button btJsonType;
        private System.Windows.Forms.Button btTxtType;
        private System.Windows.Forms.Label lbInf;
        private System.Windows.Forms.Label lbInfo;
    }
}

