using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;


namespace tracker.file
{
    public partial class frmMonitoring : Form
    {
        frmTrainlist m_trainList = new frmTrainlist();
        frmRadioList m_radioList = new frmRadioList();
        frmMap m_map = new frmMap();
        private string _ip;
        private string _username;
        private string _version;
        private int counter;
        private DateTime previous;
        private DateTime latest;

        public string ip
        {
            set
            {
                _ip = value;
            }
        }

        public string username
        {
            set
            {
                _username = value;
            }
        }

        public string version
        {
            set
            {
                _version = value;
            }
        }
        public frmMonitoring()
        {
            InitializeComponent();
        }

        private void frmMonitoring_Load(object sender, EventArgs e)
        {
            statusLbl.Text = _username;
            statusIp.Text =  _ip;
            statusVersion.Text = _version;
            openTrainlist();
        }


        private void openTrainlist()
        {
            
            dockPanel.DockLeftPortion = 250;

            m_trainList.CloseButtonVisible = false;
            
            m_trainList.Show(dockPanel, DockState.DockLeft);

            m_radioList.CloseButtonVisible = false;
            m_radioList.Show(dockPanel, DockState.Float);
            m_radioList.DockHandler.FloatPane.DockTo(dockPanel.DockWindows[DockState.DockLeft]);



           
            m_map.CloseButtonVisible = false;
            if (dockPanel.DocumentStyle == DocumentStyle.SystemMdi)
            {
                m_map.MdiParent = this;
                m_map.Show();
            }
            else
                m_map.Show(dockPanel);
        }

        private void mapSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (frmMapSettings mapSettings = new frmMapSettings())
            {
                mapSettings.ShowDialog();
            }

            m_map.initMap();
        }

        private void dockPanel_ActiveContentChanged(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            if (MysqlHelper.TestConnection())
            {
                DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * from settings WHERE id = 1");
                if (counter == 1)
                {
                    previous = Convert.ToDateTime(dt.Rows[0]["last_update"]);
                }


                if (counter == 3)
                {
                    latest = Convert.ToDateTime(dt.Rows[0]["last_update"]);

                    if (previous == latest)
                    {
                        previous = Convert.ToDateTime(dt.Rows[0]["last_update"]);
                        statusTnx.Text = "Server is not running";
                        statusTnx.ForeColor = Color.Red;
                    }
                    else
                    {
                        statusTnx.Text = "Server is running";
                        statusTnx.ForeColor = Color.Green;
                    }

                    counter = 0;
                }
                counter++;
            }
            else
            {
                Application.Exit();
            }

            timer1.Enabled = true;
        }

    }
}
