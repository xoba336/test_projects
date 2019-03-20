namespace TextEditor.Forms
{
    partial class FormName
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
            this.tbFileName = new System.Windows.Forms.TextBox();
            this.lbNameFile = new System.Windows.Forms.Label();
            this.btSaveFileName = new System.Windows.Forms.Button();
            this.lbFileFormat = new System.Windows.Forms.Label();
            this.cbFileType = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // tbFileName
            // 
            this.tbFileName.Location = new System.Drawing.Point(89, 15);
            this.tbFileName.Name = "tbFileName";
            this.tbFileName.Size = new System.Drawing.Size(121, 20);
            this.tbFileName.TabIndex = 0;
            // 
            // lbNameFile
            // 
            this.lbNameFile.AutoSize = true;
            this.lbNameFile.Location = new System.Drawing.Point(13, 18);
            this.lbNameFile.Name = "lbNameFile";
            this.lbNameFile.Size = new System.Drawing.Size(55, 13);
            this.lbNameFile.TabIndex = 1;
            this.lbNameFile.Text = "File name:";
            // 
            // btSaveFileName
            // 
            this.btSaveFileName.Location = new System.Drawing.Point(89, 93);
            this.btSaveFileName.Name = "btSaveFileName";
            this.btSaveFileName.Size = new System.Drawing.Size(75, 23);
            this.btSaveFileName.TabIndex = 2;
            this.btSaveFileName.Text = "Save";
            this.btSaveFileName.UseVisualStyleBackColor = true;
            this.btSaveFileName.Click += new System.EventHandler(this.btSaveFileName_Click);
            // 
            // lbFileFormat
            // 
            this.lbFileFormat.AutoSize = true;
            this.lbFileFormat.Location = new System.Drawing.Point(16, 51);
            this.lbFileFormat.Name = "lbFileFormat";
            this.lbFileFormat.Size = new System.Drawing.Size(72, 13);
            this.lbFileFormat.TabIndex = 3;
            this.lbFileFormat.Text = "Save as type:";
            // 
            // cbFileType
            // 
            this.cbFileType.FormattingEnabled = true;
            this.cbFileType.Location = new System.Drawing.Point(89, 48);
            this.cbFileType.Name = "cbFileType";
            this.cbFileType.Size = new System.Drawing.Size(121, 21);
            this.cbFileType.TabIndex = 4;
            // 
            // FormName
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(248, 139);
            this.Controls.Add(this.cbFileType);
            this.Controls.Add(this.lbFileFormat);
            this.Controls.Add(this.btSaveFileName);
            this.Controls.Add(this.lbNameFile);
            this.Controls.Add(this.tbFileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormName";
            this.Text = "Enter file name";
            this.Load += new System.EventHandler(this.FormName_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tbFileName;
        private System.Windows.Forms.Label lbNameFile;
        private System.Windows.Forms.Button btSaveFileName;
        private System.Windows.Forms.Label lbFileFormat;
        private System.Windows.Forms.ComboBox cbFileType;
    }
}