using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using tracker.maintenance;
using tracker.file;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace tracker
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void radioMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRadio radio = new frmRadio())
            {
                radio.ShowDialog();
            }            
        }

        private void trainMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmTrain train = new frmTrain())
            {
                train.ShowDialog();
            } 
        }

        private void trainRadioAssignmentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmTrainRadio trainRadio = new frmTrainRadio())
            {
                trainRadio.ShowDialog();
            }
        }


        private void monitoringToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (frmMonitoring monitoring = new frmMonitoring())
            {
                this.Hide();
                monitoring.WindowState = FormWindowState.Maximized;
                monitoring.ShowDialog();
            }
            this.Show();

            //frmMonitoring monitoring = new frmMonitoring();
            //monitoring.MdiParent = this;
            //monitoring.Show();
            //monitoring.WindowState = FormWindowState.Maximized;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            this.Hide();

            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
            {
                try
                {
                        conn.Open();
                     
                        conn.Close();

                        if (Properties.Settings.Default.Mode == 1)
                        {
                            DialogResult dr = new DialogResult();
                            frmLogin logIn = new frmLogin();
                            dr = logIn.ShowDialog();

                            if (dr == DialogResult.OK)
                            {
                                this.Show();
                            }
                            else
                            {
                                this.Close();
                            }
                        }
                        else
                        {
                            menuStrip1.Items[1].Visible = false;
                            menuStrip1.Items[2].Visible = false;

                            this.Show();
                        }
                    
                }
                catch (MySqlException ex)
                {
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.  Contact administrator","Database Connection Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
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
                    DialogResult dr = new DialogResult();
                    frmServerSettings settings = new frmServerSettings();
                    dr = settings.ShowDialog();
                    if (dr == DialogResult.OK)
                    {
                        Application.Restart();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
           }

            
            
            

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAbout about = new frmAbout();
            about.ShowDialog();
        }

        private void viewHelpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Help.ShowHelp(this, "file://c:\\helpfiles\\help.chm");
        }

        private void initializeDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmInitDb initDb = new frmInitDb())
            {
                initDb.ShowDialog();
            } 
        }
    }
}
