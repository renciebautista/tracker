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
        private Boolean msgShown;
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

            string filepath = Properties.Settings.Default.Wallpaper.ToString();
            if (filepath != "")
            {
                pictureBox1.Image = Image.FromFile(filepath);
            }

            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
            {
                try
                {
                        conn.Open();
                     
                        conn.Close();

                        DialogResult dr = new DialogResult();
                        frmLogin logIn = new frmLogin();
                        dr = logIn.ShowDialog();

                        if (dr == DialogResult.OK)
                        {
                            if (userdetails.GroupId == 2)
                            {
                                menuStrip1.Items[1].Visible = false;
                            }
                            this.Show();
                            msgShown = false;
                        }
                        else
                        {
                            this.Close();
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

        private void userMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmUser user = new frmUser())
            {
                user.ShowDialog();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * from settings WHERE id = 1");
            if (DateTime.Now.Subtract(Convert.ToDateTime(dt.Rows[0]["last_update"])).TotalSeconds > 5)
            {
                // timer1.Enabled = false;
                notifyIcon1.BalloonTipIcon = ToolTipIcon.Warning;
                notifyIcon1.BalloonTipText = "Please check Tracker System server.";
                notifyIcon1.BalloonTipTitle = "Tracker service is not running";

                notifyIcon1.ShowBalloonTip(1000);

                //DialogResult result = MessageBox.Show("Tracker service is not running", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                //if (result == DialogResult.OK)
                //{
                //    timer1.Enabled = true;
                //}
                
            }
            
           
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmBackground background = new frmBackground())
            {
                background.ShowDialog();
            }

            string filepath = Properties.Settings.Default.Wallpaper.ToString();
            if (filepath != "")
            {
                pictureBox1.Image = Image.FromFile(filepath);
            }
        }

        private void relogToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
