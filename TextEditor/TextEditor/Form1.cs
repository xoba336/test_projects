using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Diagnostics;
using System.Collections.Generic;
using TextEditor.Helper;

namespace TextEditor
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Crete Database if not exist
            DatabaseHelper.CreteDatabase();

            //this.gv_Files
            //Read to GridView files

            Task<DataTable> asyncTask = Task<DataTable>.Factory.StartNew(() => DatabaseHelper.ReadFilesFromDB());
            DataTable dtFiles = asyncTask.Result;
            //DataTable dtFiles = DatabaseHelper.ReadFilesFromDB();

            gv_Files.DataSource = dtFiles;

            
            //gv_Files.Refresh();

        }

        private void btn_AddFile_Click(object sender, EventArgs e)
        {
            Task.Run(()=>DatabaseHelper.AddFileToDB());
        }

        private void gv_Files_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //MessageBox.Show("Click");
            //int clickedRow = e.RowIndex;

            string clickedFile = gv_Files.Rows[e.RowIndex].Cells["file"].Value.ToString();
            rtb_MainEditor.Clear();
            rtb_MainEditor.AppendText(clickedFile);
            string q = "qqq";
        }
    }
}
