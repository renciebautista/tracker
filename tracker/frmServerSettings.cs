using MySql.Data.MySqlClient;
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

namespace tracker
{
    public partial class frmServerSettings : Form
    {
        public frmServerSettings()
        {
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            ConnectionStringsSection section = config.GetSection("connectionStrings") as ConnectionStringsSection;
            if (section != null)
            {
                section.ConnectionStrings["default"].ConnectionString = txtSettings.Text;
                config.Save();
            }

            this.DialogResult = DialogResult.OK;
        }

        private void frmServerSettings_Load(object sender, EventArgs e)
        {
            txtSettings.Text = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            using (MySqlConnection conn = new MySqlConnection(txtSettings.Text))
            {
                try
                {
                    conn.Open();
                    conn.Close();
                    MessageBox.Show("Connection Successful", "Database Connection", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.  Contact administrator", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        case 1042:
                            MessageBox.Show("Unable to connect to any of the specified MySQL hosts.", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        default:
                            MessageBox.Show("Cannot connect to server.  Contact administrator", "Database Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                    }
                }
            }
        }
    }
}
