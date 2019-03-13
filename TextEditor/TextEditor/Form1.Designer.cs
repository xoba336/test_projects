namespace TextEditor
{
    partial class Form1
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
            this.btn_AddFile = new System.Windows.Forms.Button();
            this.gv_Files = new System.Windows.Forms.DataGridView();
            this.rtb_MainEditor = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Files)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_AddFile
            // 
            this.btn_AddFile.Location = new System.Drawing.Point(12, 12);
            this.btn_AddFile.Name = "btn_AddFile";
            this.btn_AddFile.Size = new System.Drawing.Size(90, 23);
            this.btn_AddFile.TabIndex = 0;
            this.btn_AddFile.Text = "AddFileToDB";
            this.btn_AddFile.UseVisualStyleBackColor = true;
            this.btn_AddFile.Click += new System.EventHandler(this.btn_AddFile_Click);
            // 
            // gv_Files
            // 
            this.gv_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Files.Location = new System.Drawing.Point(12, 42);
            this.gv_Files.Name = "gv_Files";
            this.gv_Files.Size = new System.Drawing.Size(237, 396);
            this.gv_Files.TabIndex = 1;
            this.gv_Files.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Files_CellDoubleClick);
            // 
            // rtb_MainEditor
            // 
            this.rtb_MainEditor.Location = new System.Drawing.Point(267, 42);
            this.rtb_MainEditor.Name = "rtb_MainEditor";
            this.rtb_MainEditor.Size = new System.Drawing.Size(521, 396);
            this.rtb_MainEditor.TabIndex = 2;
            this.rtb_MainEditor.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.rtb_MainEditor);
            this.Controls.Add(this.gv_Files);
            this.Controls.Add(this.btn_AddFile);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Files)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_AddFile;
        private System.Windows.Forms.DataGridView gv_Files;
        private System.Windows.Forms.RichTextBox rtb_MainEditor;
    }
}

