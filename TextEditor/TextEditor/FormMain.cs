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
using System.Text.RegularExpressions;
using System.Drawing;
using System.Threading;
using TextEditor.Enums;

namespace TextEditor
{
    public partial class FormMain : Form
    {
        private InfoLabel _InfoLabel; //Label to print info on main form

        #region Initialization

        public FormMain()
        {
            InitializeComponent();
            _InfoLabel = new InfoLabel(lbInfo);
        }

        #endregion

        #region Event Handlers

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string storageType = GetSelectedItem(fileStorageToolStripMenuItem);
            OpenFile(storageType);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string storageType = GetSelectedItem(fileStorageToolStripMenuItem);
            SaveFile(storageType);
        }

        private void hddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckedToolStripItem(fileStorageToolStripMenuItem, hddToolStripMenuItem);
        }

        private void databaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CheckedToolStripItem(fileStorageToolStripMenuItem, databaseToolStripMenuItem);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (rtb_MainEditor.Text != "" && rtb_MainEditor.Text != null)
            {
                DialogResult = MessageBox.Show("File not empty. Create new?", "Create new.", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (DialogResult == DialogResult.No || DialogResult == DialogResult.Cancel)
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

        private void btXmlType_Click(object sender, EventArgs e)
        {
            XMLHighlight();
        }

        private void btJsonType_Click(object sender, EventArgs e)
        {
            JsonHilight();
        }

        private void btTxtType_Click(object sender, EventArgs e)
        {
            rtb_MainEditor.SelectAll();
            rtb_MainEditor.SelectionColor = Color.Empty;
            rtb_MainEditor.DeselectAll();
        }

        #endregion

        #region Private Methods

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

                    OpenFileFromHDD(of.FileName);
                    _InfoLabel.Print(of.FileName + " opened. Storage: " + storageType);
                    break;
                case "Database":
                    using (var formDBFiles = new FormDatabaseFiles())
                    {
                        var result = formDBFiles.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            rtb_MainEditor.Clear();

                            //Open file in Task, Task return value
                            Task<string> fileFromDB = Task<string>.Factory.StartNew(() => DatabaseHelper.ReadFileContentByID(formDBFiles.SelectedFileId));

                            rtb_MainEditor.AppendText(fileFromDB.Result);
                            SetGlobalFileName(formDBFiles.FileName, formDBFiles.FileType);
                            _InfoLabel.Print(formDBFiles.FileName + " opened. Storage: " + storageType);
                        }
                    }
                    break;
            }
        }

        private void OpenFileFromHDD(string fileName)
        {
            string file_hdd = File.ReadAllText(fileName, Encoding.UTF8);

            rtb_MainEditor.Text = file_hdd;
            rtb_MainEditor.AppendText(file_hdd);
            rtb_MainEditor.Select(0, 0);
            rtb_MainEditor.ScrollToCaret();

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
                    string fileName = System.IO.Path.GetFileNameWithoutExtension(sf.FileName);

                    System.IO.File.WriteAllText(sf.FileName, rtb_MainEditor.Text);

                    SetGlobalFileName(System.IO.Path.GetFileNameWithoutExtension(sf.FileName), System.IO.Path.GetExtension(sf.FileName));
                    _InfoLabel.Print(fileName + " saved. Storage: " + type);
                    break;
                case "Database":
                    using (var fileNameForm = new FormName(GlobalFileInfo.FileName, GlobalFileInfo.FileType))
                    {
                        var result = fileNameForm.ShowDialog();
                        if (result == DialogResult.OK)
                        {
                            string content = rtb_MainEditor.Text;

                            //Save file in task
                            Task.Run(() => DatabaseHelper.SaveFileToDatabase(content, fileNameForm.FileName, fileNameForm.FileType, _InfoLabel));

                            SetGlobalFileName(fileNameForm.FileName, fileNameForm.FileType);
                        }
                    }
                    break;

                default:
                    break;
            }

        }

        private string GetSelectedItem(ToolStripMenuItem menu)
        {
            //Return checked storage 
            Dictionary<string, bool> menuItems = new Dictionary<string, bool>();
            foreach (ToolStripMenuItem item in menu.DropDown.Items)
            {
                menuItems.Add(item.Text, item.Checked);
            }
            return menuItems.Where(x => x.Value == true).Select(x => x.Key).ToList().FirstOrDefault();
        }

        private void SetGlobalFileName(string fileName, string fileType)
        {
            GlobalFileInfo.FileName = fileName;
            GlobalFileInfo.FileType = fileType;
            this.Text = fileName + " - Text Editor";
        }

        private void XMLHighlight() //Highligft xml syntax
        {
            //Set List of regex and colors for xml syntax
            List<RegexColor> matches = new List<RegexColor>();
            matches.Add(new RegexColor() { Regex = @"<[^>]+>", Color = Color.Brown, });
            matches.Add(new RegexColor() { Regex = @"<\?|<|/>|</|>|\?>", Color = Color.Blue });

            //Get List of Matches and colors for hilight xml
            List<MatchesHilight> matchesList = GetAllMatchesHilighting(matches);

            //Hilight xml
            foreach (MatchesHilight item in matchesList)
            {
                rtb_MainEditor.Select(item.Match.Index, item.Match.Length);
                rtb_MainEditor.SelectionColor = item.Color;
            }
        }

        private void JsonHilight() //Highligft json syntax
        {
            //Set List of regex and colors for json syntax
            List<RegexColor> matches = new List<RegexColor>();
            matches.Add(new RegexColor() { Regex = "\"(.*?)\"", Color = Color.Brown,  });
            matches.Add(new RegexColor() { Regex = ": \"(.*?)\"", Color = Color.Blue });
            matches.Add(new RegexColor() { Regex = ":\"(.*?)\"", Color = Color.Blue });

            //Get List of Matches and colors for hilight json
            List<MatchesHilight> matchesList = GetAllMatchesHilighting(matches);

            //Hilight json
            foreach (MatchesHilight item in matchesList)
            {
                rtb_MainEditor.Select(item.Match.Index+1, item.Match.Length);
                rtb_MainEditor.SelectionColor = item.Color;
            }
        }

        private List<MatchesHilight> GetAllMatchesHilighting(List<RegexColor> matchesRegex) //return all mathes for highlighting methods
        {
            List<MatchesHilight> result = new List<MatchesHilight>();

            foreach (RegexColor item in matchesRegex)
            {
                foreach (Match match in Regex.Matches(rtb_MainEditor.Text, item.Regex))
                {
                    result.Add(new MatchesHilight() { Match = match, Color = item.Color });
                }
            }
            return result;
        }

        private void ChangedRowHighlight()
        {
            string[] rtbRows = rtb_MainEditor.Lines; //rows of RTB
            int curPosition = rtb_MainEditor.SelectionStart; //current cursor position
            int row = rtb_MainEditor.GetLineFromCharIndex(curPosition); //current row
            int firstCharRowInd = rtb_MainEditor.GetFirstCharIndexFromLine(row); //global index of 1 char in current row

            string changedRow = rtbRows[row];
            XMLHilightRow(changedRow, firstCharRowInd, changedRow.Length);
        }

        private void XMLHilightRow(string changedRow, int firstCharRowInd, int length)
        {
            var findElements = Regex.Matches(changedRow, @"<[^>]+>");
            if (findElements.Count > 0)
            {
                foreach (var item in findElements.Cast<Match>())
                {
                    rtb_MainEditor.Select(firstCharRowInd + item.Index, item.Length);
                    rtb_MainEditor.SelectionColor = Color.Brown;
                }
            }
            var findElementsSymbol = Regex.Matches(rtb_MainEditor.Text, @"<\?|<|/>|</|>|\?>");
            foreach (var item in findElementsSymbol.Cast<Match>())
            {
                rtb_MainEditor.Select(firstCharRowInd + item.Index, item.Length);
                rtb_MainEditor.SelectionColor = Color.Blue;
            }
            rtb_MainEditor.Select(firstCharRowInd, 0);
            rtb_MainEditor.ScrollToCaret();
        }

        private void CheckedToolStripItem(ToolStripMenuItem menu, ToolStripMenuItem checkedItem) //Checked/unchecked storage
        {
            foreach (ToolStripMenuItem item in menu.DropDown.Items)
            {
                item.Checked = false;
                if (item==checkedItem)
                {
                    item.Checked = true;
                }
            }
        }

        #endregion

        public class MatchesHilight
        {
            public Match Match { get; set; }
            public Color Color { get; set; }
        }

        public class RegexColor
        {
            public string Regex { get; set; }
            public Color Color { get; set; }
        }
    }

}
