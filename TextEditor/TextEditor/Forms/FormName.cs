using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.Enums;

namespace TextEditor.Forms
{
    public partial class FormName : Form
    {
        public string FileName = "Untitled";
        public string FileType = ".xml";
        public FormName(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
            InitializeComponent();
        }

        private void btSaveFileName_Click(object sender, EventArgs e)
        {
            if (tbFileName.Text == "" || tbFileName.Text == null)
            {
                MessageBox.Show("Enter file name", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FileName = tbFileName.Text;
            if (cbFileType.SelectedIndex == cbFileType.Items.IndexOf("Other") && FileName.IndexOf(".")>0)
            {
                FileType = FileName.Remove(0, FileName.IndexOf(".") + 1);
            }
            else
            {
                FileType = cbFileType.SelectedItem.ToString();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void FormName_Load(object sender, EventArgs e)
        {
            tbFileName.Text = FileName;
            List<string> fileTypes = Enum.GetValues(typeof(FileType)).Cast<FileType>().Select(x => x.ToString()).ToList();
            foreach (string fileT in fileTypes)
            {
                cbFileType.Items.Add("."+fileT);
            }
            if (FileType!=null && FileType!="" && cbFileType.Items.IndexOf(FileType)>0)
                cbFileType.SelectedIndex = cbFileType.Items.IndexOf(FileType);
            else
                cbFileType.SelectedIndex = cbFileType.Items.IndexOf(".xml");
        }
    }
}
