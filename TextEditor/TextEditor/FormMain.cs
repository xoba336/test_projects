using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using TextEditor.Helper;
using TextEditor.Forms;
using System.IO;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using TextEditor.Model;

namespace TextEditor
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string storageType = GetFileStorageType();
            OpenFile(storageType);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string storageType = GetFileStorageType();
            SaveFile(storageType);
        }

        private string GetFileStorageType()
        {
            Dictionary<string, bool> fileStorageTypeDic = new Dictionary<string, bool>();
            fileStorageTypeDic.Add(hddToolStripMenuItem.Text, hddToolStripMenuItem.Checked);
            fileStorageTypeDic.Add(databaseToolStripMenuItem.Text, databaseToolStripMenuItem.Checked);
            return fileStorageTypeDic.Where(x => x.Value == true).Select(x => x.Key).ToList()[0];
        }

        private void OpenFile(string storageType)
        {
            switch (storageType)
            {
                case "HDD":
                    OpenFileDialog of = new OpenFileDialog();
                    of.Title = "Open file.";
                    of.Filter = "XML|*.xml|JSON|*.json|Text|*.txt|All files(*.*)|*.*";
                    if (of.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    string fileName = of.FileName;
                    OpenFileFromHDD(fileName);
                    break;
                case "Database":
                    using (var fDbF = new FormDatabaseFiles())
                    {
                        var result = fDbF.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            rtb_MainEditor.Clear();
                            rtb_MainEditor.AppendText(DatabaseHelper.ReadFileContentByID(fDbF.SelectedFileId));
                            SetGlobalFileName(fDbF.FileName, fDbF.FileType);
                            //this.Text = fDbF.FileName;
                        }
                    }
                    break;
            }
        }

        private void OpenFileFromHDD(string fileName)
        {
            rtb_MainEditor.Clear();
            var file_qqq = File.ReadAllText(fileName, Encoding.UTF8);
            rtb_MainEditor.AppendText(file_qqq);
            SetGlobalFileName(System.IO.Path.GetFileNameWithoutExtension(fileName), System.IO.Path.GetExtension(fileName));
        }

        private void SaveFile(string type)
        {
            switch (type)
            {
                case "HDD":
                    SaveFileDialog sf = new SaveFileDialog();
                    sf.Title = "Save file to " + type;
                    sf.Filter = "XML|*.xml|JSON|*.json|TXT|*.txt|All files(*.*)|*.*";
                    sf.FileName = GlobalFileInfo.FileName;
                    if (sf.ShowDialog() == DialogResult.Cancel)
                    {
                        return;
                    }
                    string fileNamePath = sf.FileName;
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(sf.FileName);
                    string fileType = System.IO.Path.GetExtension(sf.FileName);
                    System.IO.File.WriteAllText(fileNamePath, rtb_MainEditor.Text);
                    SetGlobalFileName(System.IO.Path.GetFileNameWithoutExtension(sf.FileName), System.IO.Path.GetExtension(sf.FileName));
                    //MessageBox.Show("Saved");
                    break;
                case "Database":

                    using (var fileNameForm = new FormName(GlobalFileInfo.FileName,GlobalFileInfo.FileType))
                    {
                        var result = fileNameForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string content = rtb_MainEditor.Text;
                            Task.WaitAll(Task.Run(() => DatabaseHelper.SaveFileToDatabase(content, fileNameForm.FileName, fileNameForm.FileType)));
                            SetGlobalFileName(fileNameForm.FileName, fileNameForm.FileType);
                        }
                    }
                    break;

                default:
                    break;
            }
            
        }

        private void hddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (hddToolStripMenuItem.Checked)
                hddToolStripMenuItem.Checked = false;
            else
            {
                hddToolStripMenuItem.Checked = true;
                databaseToolStripMenuItem.Checked = false;
            }
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (databaseToolStripMenuItem.Checked)
                databaseToolStripMenuItem.Checked = false;
            else
            {
                databaseToolStripMenuItem.Checked = true;
                hddToolStripMenuItem.Checked = false;
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_MainEditor.Text != "" && rtb_MainEditor.Text!=null)
            {
                DialogResult = MessageBox.Show("File not empty. Create new?", "Create new.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if(DialogResult == DialogResult.No || DialogResult == DialogResult.Cancel)
                {
                    return;
                }
            }
            rtb_MainEditor.Clear();
            SetGlobalFileName("Untitled", "");
        }

        private void conToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = new FormSettings
            {
                Owner = this
            };
            settings.Show();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout about = new FormAbout();
            about.Show();
        }

        private void SetGlobalFileName(string fileName, string fileType)
        {
            GlobalFileInfo.FileName = fileName;
            GlobalFileInfo.FileType = fileType;
            this.Text = fileName + " - Text Editor";
        }
    }
}
