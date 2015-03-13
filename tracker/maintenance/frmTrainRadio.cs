using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tracker.maintenance
{
    public partial class frmTrainRadio : Form
    {
        BindingSource bs = new BindingSource();
        public frmTrainRadio()
        {
            InitializeComponent();
        }

        private void loadGrid()
        {
            dgvTrainRadio.AutoGenerateColumns = false;
            bs.DataSource = MysqlHelper.ExecuteDataTable("SELECT train_radios.id,trains.train_desc,rd1.ssi as radio_1,rd2.ssi as radio_2  FROM train_radios" +
                " JOIN trains ON train_radios.train_id = trains.id" +
                " JOIN radios as rd1 ON train_radios.radio_id_1 = rd1.id" +
                " JOIN radios as rd2 ON train_radios.radio_id_2 = rd2.id");
            bdgNavigator.BindingSource = bs;
            dgvTrainRadio.DataSource = bs;


        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        

        private void frmTrainRadio_Load(object sender, EventArgs e)
        {
            loadGrid();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (frmAddTrain addTrain = new frmAddTrain())
            {
                addTrain.ShowDialog();
            }

            loadGrid();
        }

    }
}
