namespace TextEditor.Forms
{
    partial class FormDatabaseFiles
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
            this.gv_Files = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gv_Files)).BeginInit();
            this.SuspendLayout();
            // 
            // gv_Files
            // 
            this.gv_Files.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv_Files.Location = new System.Drawing.Point(0, 0);
            this.gv_Files.MultiSelect = false;
            this.gv_Files.Name = "gv_Files";
            this.gv_Files.ReadOnly = true;
            this.gv_Files.Size = new System.Drawing.Size(379, 448);
            this.gv_Files.TabIndex = 2;
            this.gv_Files.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv_Files_CellDoubleClick);
            // 
            // FormDatabaseFiles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 450);
            this.Controls.Add(this.gv_Files);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormDatabaseFiles";
            this.Text = "Database Files";
            this.Load += new System.EventHandler(this.FormDatabaseFiles_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gv_Files)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gv_Files;
    }
}