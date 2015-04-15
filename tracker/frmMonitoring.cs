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


namespace tracker
{
    public partial class frmMonitoring : Form
    {
        private frmTrainlist m_trainList;
        public frmMonitoring()
        {
            InitializeComponent();
        }

        private void frmMonitoring_Load(object sender, EventArgs e)
        {
            openTrainlist();
        }

        private void trainlistToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openTrainlist();
        }

        private void openTrainlist()
        {
            frmTrainlist m_trainList = new frmTrainlist();
            m_trainList.Show(dockPanel, DockState.DockLeft);
        }

    }
}
