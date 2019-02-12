namespace Test_V_Clinic
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
            this.components = new System.ComponentModel.Container();
            this.dgrid_animals = new System.Windows.Forms.DataGridView();
            this.lb_Animal = new System.Windows.Forms.Label();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.heightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.weightDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.indoorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nicknameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userstoredbDataSet = new Test_V_Clinic.userstoredbDataSet();
            this.animalsBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.animalsTableAdapter = new Test_V_Clinic.userstoredbDataSetTableAdapters.AnimalsTableAdapter();
            this.bt_Add = new System.Windows.Forms.Button();
            this.bt_Edit = new System.Windows.Forms.Button();
            this.bt_Delete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.animalsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_animals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.userstoredbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalsBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalsBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgrid_animals
            // 
            this.dgrid_animals.AllowUserToAddRows = false;
            this.dgrid_animals.AutoGenerateColumns = false;
            this.dgrid_animals.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgrid_animals.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.heightDataGridViewTextBoxColumn,
            this.weightDataGridViewTextBoxColumn,
            this.indoorDataGridViewTextBoxColumn,
            this.nicknameDataGridViewTextBoxColumn});
            this.dgrid_animals.DataSource = this.animalsBindingSource1;
            this.dgrid_animals.Location = new System.Drawing.Point(12, 28);
            this.dgrid_animals.Name = "dgrid_animals";
            this.dgrid_animals.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgrid_animals.Size = new System.Drawing.Size(776, 163);
            this.dgrid_animals.TabIndex = 0;
            // 
            // lb_Animal
            // 
            this.lb_Animal.AutoSize = true;
            this.lb_Animal.Location = new System.Drawing.Point(13, 9);
            this.lb_Animal.Name = "lb_Animal";
            this.lb_Animal.Size = new System.Drawing.Size(43, 13);
            this.lb_Animal.TabIndex = 1;
            this.lb_Animal.Text = "Animals";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // heightDataGridViewTextBoxColumn
            // 
            this.heightDataGridViewTextBoxColumn.DataPropertyName = "Height";
            this.heightDataGridViewTextBoxColumn.HeaderText = "Height";
            this.heightDataGridViewTextBoxColumn.Name = "heightDataGridViewTextBoxColumn";
            // 
            // weightDataGridViewTextBoxColumn
            // 
            this.weightDataGridViewTextBoxColumn.DataPropertyName = "Weight";
            this.weightDataGridViewTextBoxColumn.HeaderText = "Weight";
            this.weightDataGridViewTextBoxColumn.Name = "weightDataGridViewTextBoxColumn";
            // 
            // indoorDataGridViewTextBoxColumn
            // 
            this.indoorDataGridViewTextBoxColumn.DataPropertyName = "Indoor";
            this.indoorDataGridViewTextBoxColumn.HeaderText = "Indoor";
            this.indoorDataGridViewTextBoxColumn.Name = "indoorDataGridViewTextBoxColumn";
            // 
            // nicknameDataGridViewTextBoxColumn
            // 
            this.nicknameDataGridViewTextBoxColumn.DataPropertyName = "Nickname";
            this.nicknameDataGridViewTextBoxColumn.HeaderText = "Nickname";
            this.nicknameDataGridViewTextBoxColumn.Name = "nicknameDataGridViewTextBoxColumn";
            // 
            // userstoredbDataSet
            // 
            this.userstoredbDataSet.DataSetName = "userstoredbDataSet";
            this.userstoredbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // animalsBindingSource1
            // 
            this.animalsBindingSource1.DataMember = "Animals";
            this.animalsBindingSource1.DataSource = this.userstoredbDataSet;
            // 
            // animalsTableAdapter
            // 
            this.animalsTableAdapter.ClearBeforeFill = true;
            // 
            // bt_Add
            // 
            this.bt_Add.Location = new System.Drawing.Point(12, 209);
            this.bt_Add.Name = "bt_Add";
            this.bt_Add.Size = new System.Drawing.Size(75, 23);
            this.bt_Add.TabIndex = 2;
            this.bt_Add.Text = "Добавить";
            this.bt_Add.UseVisualStyleBackColor = true;
            this.bt_Add.Click += new System.EventHandler(this.bt_Add_Click);
            // 
            // bt_Edit
            // 
            this.bt_Edit.Location = new System.Drawing.Point(94, 209);
            this.bt_Edit.Name = "bt_Edit";
            this.bt_Edit.Size = new System.Drawing.Size(75, 23);
            this.bt_Edit.TabIndex = 3;
            this.bt_Edit.Text = "Редактировать";
            this.bt_Edit.UseVisualStyleBackColor = true;
            this.bt_Edit.Click += new System.EventHandler(this.bt_Edit_Click);
            // 
            // bt_Delete
            // 
            this.bt_Delete.Location = new System.Drawing.Point(176, 209);
            this.bt_Delete.Name = "bt_Delete";
            this.bt_Delete.Size = new System.Drawing.Size(75, 23);
            this.bt_Delete.TabIndex = 4;
            this.bt_Delete.Text = "Удалить";
            this.bt_Delete.UseVisualStyleBackColor = true;
            this.bt_Delete.Click += new System.EventHandler(this.bt_Delete_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(712, 209);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // animalsBindingSource
            // 
            this.animalsBindingSource.DataSource = typeof(Test_V_Clinic.Model.Animals);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bt_Delete);
            this.Controls.Add(this.bt_Edit);
            this.Controls.Add(this.bt_Add);
            this.Controls.Add(this.lb_Animal);
            this.Controls.Add(this.dgrid_animals);
            this.Name = "Form1";
            this.Text = "V_Clinic";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgrid_animals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.userstoredbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalsBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.animalsBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgrid_animals;
        private System.Windows.Forms.Label lb_Animal;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn heightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn weightDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn indoorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nicknameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource animalsBindingSource;
        private userstoredbDataSet userstoredbDataSet;
        private System.Windows.Forms.BindingSource animalsBindingSource1;
        private userstoredbDataSetTableAdapters.AnimalsTableAdapter animalsTableAdapter;
        private System.Windows.Forms.Button bt_Add;
        private System.Windows.Forms.Button bt_Edit;
        private System.Windows.Forms.Button bt_Delete;
        private System.Windows.Forms.Button button1;
    }
}

