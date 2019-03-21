using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.Helper;

namespace TextEditor.Forms
{
    public partial class FormDatabaseFiles : Form
    {
        public string FileName;
        public string FileType;
        public int SelectedFileId;

        public FormDatabaseFiles()
        {
            InitializeComponent();
        }

        private void FormDatabaseFiles_Load(object sender, EventArgs e)
        {
            //Crete Database if not exist
            DatabaseHelper.CreteDatabase();
            ReadFilesFromDBtoGridView();
        }

        private void gv_Files_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex + 1 >= gv_Files.RowCount)
            {
                return;
            }
            SelectedFileId = Int32.Parse(gv_Files.Rows[e.RowIndex].Cells["id"].Value.ToString());
            FileName = gv_Files.Rows[e.RowIndex].Cells["file_name"].Value.ToString();
            FileType = gv_Files.Rows[e.RowIndex].Cells["file_format"].Value.ToString();
            this.DialogResult = DialogResult.OK;
            Close();
        }

        private void ReadFilesFromDBtoGridView()
        {
            Task<DataTable> asyncTask = Task<DataTable>.Factory.StartNew(() => DatabaseHelper.SelectAllFiles());
            DataTable dtFiles = asyncTask.Result;
            gv_Files.DataSource = dtFiles;
        }
    }
}
