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
using tracker.reports;
using NetFwTypeLib;
using System.Data.SqlClient;
using System.Reflection;
using System.Net.Sockets;
using System.Net;
using System.Threading;
namespace tracker
{
    public partial class frmMain : Form
    {
        private int counter;
        private DateTime previous;
        private DateTime latest;
        public frmMonitoring m_monitoring;
        public frmMain()
        {
            InitializeComponent();

            INetFwRule firewallRule = (INetFwRule)Activator.CreateInstance(
            Type.GetTypeFromProgID("HNetCfg.FWRule"));

            INetFwPolicy2 firewallPolicy = (INetFwPolicy2)Activator.CreateInstance(
                Type.GetTypeFromProgID("HNetCfg.FwPolicy2"));

            firewallRule.ApplicationName = Application.ExecutablePath;

            firewallRule.Action = NET_FW_ACTION_.NET_FW_ACTION_ALLOW;
            firewallRule.Description = " 10-20 Tracker Windows Firewall Rule";
            firewallRule.Enabled = true;
            firewallRule.InterfaceTypes = "All";
            firewallRule.Name = "Allow 10-20 Tracker";

            // Should really check that rule is not already present before add in
            firewallPolicy.Rules.Add(firewallRule); 
        }

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyDescription
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
            }
        }

        public string AssemblyProduct
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyProductAttribute)attributes[0]).Product;
            }
        }

        public string AssemblyCopyright
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
        }
        #endregion


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
            //timer1.Enabled = false;
            using (frmMonitoring monitoring = new frmMonitoring())
            {
                monitoring.ip = statusIp.Text;
                //monitoring.username = statusLbl.Text;
                monitoring.version = statusVersion.Text;
                monitoring.WindowState = FormWindowState.Maximized;
                m_monitoring = monitoring;
                monitoring.ShowDialog();
                m_monitoring = null;
            }
           
            //.Enabled = true;

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Thread thdUDPServer = new Thread(new ThreadStart(serverThread));
            thdUDPServer.IsBackground = true;
            thdUDPServer.Start();

            counter = 0;
            this.Hide();
            string filepath = Properties.Settings.Default.Wallpaper.ToString();
            if (filepath != "")
            {
                pictureBox1.Image = Image.FromFile(filepath);
            }
            else
            {
                try
                {
                    var path = Application.StartupPath + @"\images\10-20 tracker background.png";
                    pictureBox1.Image = Image.FromFile(path);
                }
                catch
                {

                }
                
            }

            using (MySqlConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["default"].ConnectionString))
            {
                try
                {
                        conn.Open();
                     
                        conn.Close();
                        migrate();
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
                            string connectString = ConfigurationManager.ConnectionStrings["default"].ToString();
                            MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder(connectString);
                            // Retrieve the DataSource property.    
                           // string IPAddress = builder.Server;
                            //statusLbl.Text = logIn.username;
                            //statusIp.Text = "@" +IPAddress;

                            statusVersion.Text = AssemblyVersion;
                            //timer1.Enabled = true;
 
                        }
                        else
                        {
                            Application.Exit();
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

            statusTnx.Text = "Server is not running";
            statusTnx.ForeColor = Color.Red;
           
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

        private void trainLogsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {

            using (frmTrainReport report = new frmTrainReport())
            {
                report.ShowDialog();
            }
           
        }

        private void radioLogsReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmRadioReport report = new frmRadioReport())
            {
                report.ShowDialog();
            }
        }

        private void migrate()
        {
            // CREATE TABLE IF NOT EXISTS migration_version ( id bigint(200) NOT NULL) ENGINE=InnoDB DEFAULT CHARSET=latin1
            // ALTER TABLE `radios` ADD `image_index` INT NOT NULL AFTER `tracker_code`;
            // CREATE TABLE IF NOT EXISTS `radio_logs` ( `id` bigint(200) NOT NULL, `radio_id` int(11) NOT NULL, `mcc` varchar(50) NOT NULL, `mnc` varchar(50) NOT NULL, `ssi` varchar(50) NOT NULL, `subscriber_name` varchar(255) NOT NULL, `uplink` int(11) NOT NULL, `speed` decimal(11,4) NOT NULL, `course` decimal(11,4) NOT NULL, `alt` decimal(11,4) NOT NULL, `max_pos_error` decimal(11,4) NOT NULL, `lat` decimal(16,13) NOT NULL, `lng` decimal(16,13) NOT NULL, `tracker_code` varchar(50) NOT NULL, `created_at` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1

            // ALTER TABLE `radio_logs` ADD `image_index` INT NOT NULL AFTER `tracker_code`;
            // ALTER TABLE `logs` ADD `image_index` INT NOT NULL AFTER `head`;

            DataTable dt = MysqlHelper.ExecuteDataTable("SHOW columns from radios where field='image_index'");
            if (dt.Rows.Count == 0)
            {
                MysqlHelper.ExecuteNonQuery("ALTER TABLE radios ADD image_index INT NOT NULL AFTER tracker_code");
            }

            MysqlHelper.ExecuteNonQuery("CREATE TABLE IF NOT EXISTS radio_logs ( id bigint(200) NOT NULL, radio_id int(11) NOT NULL, mcc varchar(50) NOT NULL, mnc varchar(50) NOT NULL, ssi varchar(50) NOT NULL, subscriber_name varchar(255) NOT NULL, uplink int(11) NOT NULL, speed decimal(11,4) NOT NULL, course decimal(11,4) NOT NULL, alt decimal(11,4) NOT NULL, max_pos_error decimal(11,4) NOT NULL, lat decimal(16,13) NOT NULL, lng decimal(16,13) NOT NULL, tracker_code varchar(50) NOT NULL, created_at timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ) ENGINE=InnoDB DEFAULT CHARSET=latin1 AUTO_INCREMENT=1");



            DataTable dt2 = MysqlHelper.ExecuteDataTable("SHOW columns from radio_logs where field='image_index'");
            if (dt2.Rows.Count == 0)
            {
                MysqlHelper.ExecuteNonQuery("ALTER TABLE radio_logs ADD image_index INT NOT NULL AFTER tracker_code");
            }

            DataTable dt3 = MysqlHelper.ExecuteDataTable("SHOW columns from logs where field='image_index'");
            if (dt3.Rows.Count == 0)
            {
                MysqlHelper.ExecuteNonQuery("ALTER TABLE logs ADD image_index INT NOT NULL AFTER head");
            }

            DataTable dt4 = MysqlHelper.ExecuteDataTable("SHOW tables like 'servers'");
            if (dt4.Rows.Count == 0)
            {
                MysqlHelper.ExecuteNonQuery("CREATE TABLE `servers` (`id` int(11) NOT NULL AUTO_INCREMENT,`ip` varchar(45) DEFAULT NULL,PRIMARY KEY (`id`)) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;");
            }
           
        }

        private void radioServeMaintenanceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmServer server = new frmServer())
            {
                server.ShowDialog();
            }
        }

        private void proccessConnection(string ip, bool status)
        {
            if (!status)
            {
                statusTnx.Text = "Server is not running";
                statusTnx.ForeColor = Color.Red;
                statusIp.Text = "Connecting ...";
            }
            else
            {
                statusTnx.Text = "Server is running";
                statusTnx.ForeColor = Color.Green;
                statusIp.Text = ip;
            }
            
        }
        public void serverThread()
        {
            UdpClient client = new UdpClient();

            client.ExclusiveAddressUse = false;
            IPEndPoint localEp = new IPEndPoint(IPAddress.Any, 5000);

            client.Client.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            client.ExclusiveAddressUse = false;

            client.Client.Bind(localEp);

            IPAddress multicastaddress = IPAddress.Parse("225.4.5.6");
            client.JoinMulticastGroup(multicastaddress);

            //Console.WriteLine("Listening this will never quit so you will need to ctrl-c it");

            while (true)
            {
                Byte[] data = client.Receive(ref localEp);
                string strData = Encoding.ASCII.GetString(data);
                //Console.WriteLine(strData);
                this.Invoke((MethodInvoker)delegate
                {
                    string[] rxdata = strData.Split('|');
                    bool status = false;
                    if (rxdata[0] == "tnx")
                    {
                        timer1.Enabled = false;
                        timer1.Interval = 1000 * (Convert.ToInt32(rxdata[3])) + 500;
                        if(rxdata[2] == "1"){
                            status = true;
                        }

                        if (m_monitoring != null)
                        {
                            m_monitoring.proccessConnection(rxdata[1], status);
                        }
                        proccessConnection(rxdata[1], status);
                        timer1.Enabled = true;
                    }
                   
                });
            }
        }
    }
}
