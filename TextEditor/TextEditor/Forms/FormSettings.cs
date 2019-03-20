using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor.Forms
{
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();
        }

        private void FormSettings_Load(object sender, EventArgs e)
        {
            Owner.Enabled = false;

            tbConn.Text = ConfigurationManager.ConnectionStrings[0].ToString();
        }

        private void FormSettings_FormClosed(object sender, FormClosedEventArgs e)
        {
            Owner.Enabled = true;
        }

        private void btDefault_Click(object sender, EventArgs e)
        {
            tbConn.Text = "Data Source=mydatabase.db";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var connectionStringSection = (ConnectionStringsSection)config.GetSection("connectionStrings");
            connectionStringSection.ConnectionStrings[0].ConnectionString = tbConn.Text;
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("connectionStrings");
            Close();
        }
    }
}
