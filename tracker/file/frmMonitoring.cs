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
        public frmMonitoring()
        {
            InitializeComponent();
        }

        private void frmMonitoring_Load(object sender, EventArgs e)
        {
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

    }
}
