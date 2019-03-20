namespace TextEditor.Forms
{
    partial class FormSettings
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
            this.tabSettings = new System.Windows.Forms.TabControl();
            this.tabConn = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbConn = new System.Windows.Forms.Label();
            this.tbConn = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btDefault = new System.Windows.Forms.Button();
            this.tabSettings.SuspendLayout();
            this.tabConn.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabSettings
            // 
            this.tabSettings.Controls.Add(this.tabConn);
            this.tabSettings.Location = new System.Drawing.Point(13, 13);
            this.tabSettings.Name = "tabSettings";
            this.tabSettings.SelectedIndex = 0;
            this.tabSettings.Size = new System.Drawing.Size(459, 293);
            this.tabSettings.TabIndex = 0;
            // 
            // tabConn
            // 
            this.tabConn.Controls.Add(this.btDefault);
            this.tabConn.Controls.Add(this.groupBox1);
            this.tabConn.Location = new System.Drawing.Point(4, 22);
            this.tabConn.Name = "tabConn";
            this.tabConn.Padding = new System.Windows.Forms.Padding(3);
            this.tabConn.Size = new System.Drawing.Size(451, 267);
            this.tabConn.TabIndex = 0;
            this.tabConn.Text = "Connection string";
            this.tabConn.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbConn);
            this.groupBox1.Controls.Add(this.tbConn);
            this.groupBox1.Location = new System.Drawing.Point(7, 7);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(441, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lbConn
            // 
            this.lbConn.AutoSize = true;
            this.lbConn.Location = new System.Drawing.Point(7, 19);
            this.lbConn.Name = "lbConn";
            this.lbConn.Size = new System.Drawing.Size(92, 13);
            this.lbConn.TabIndex = 1;
            this.lbConn.Text = "Connection string:";
            // 
            // tbConn
            // 
            this.tbConn.Location = new System.Drawing.Point(105, 16);
            this.tbConn.Name = "tbConn";
            this.tbConn.Size = new System.Drawing.Size(330, 20);
            this.tbConn.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(392, 326);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btDefault
            // 
            this.btDefault.Location = new System.Drawing.Point(7, 238);
            this.btDefault.Name = "btDefault";
            this.btDefault.Size = new System.Drawing.Size(75, 23);
            this.btDefault.TabIndex = 1;
            this.btDefault.Text = "Default";
            this.btDefault.UseVisualStyleBackColor = true;
            this.btDefault.Click += new System.EventHandler(this.btDefault_Click);
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tabSettings);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSettings";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormSettings_FormClosed);
            this.Load += new System.EventHandler(this.FormSettings_Load);
            this.tabSettings.ResumeLayout(false);
            this.tabConn.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabSettings;
        private System.Windows.Forms.TabPage tabConn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbConn;
        private System.Windows.Forms.TextBox tbConn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btDefault;
    }
}