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
            bs.DataSource = MysqlHelper.ExecuteDataTable("SELECT train_radios.id,trains.train_code,trains.train_desc,radios.mcc,radios.mnc,radios.ssi,radios.tracker_code,"+
                "tbl2.*"+
                " FROM train_radios "+
                " INNER JOIN trains on train_radios.train_id = trains.id"+
                " INNER JOIN radios on train_radios.radio_id = radios.id"+
                " inner join ("+
                " SELECT train_radios.train_id, radios.mcc as head_mcc,radios.mnc as head_mnc,radios.ssi as head_ssi,radios.tracker_code as head_tracker_code FROM train_radios"+
                " INNER JOIN radios on train_radios.radio_id = radios.id"+
                " WHERE train_radios.head = 1"+
                ")as tbl2 on train_radios.train_id = tbl2.train_id"+
                " WHERE train_radios.head = 0");
            bdgNavigator.BindingSource = bs;
            dgvTrainRadio.DataSource = bs;

            if (dgvTrainRadio.Rows.Count < 1)
            {
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnEdit.Enabled = false;
            }
            else
            {
                btnDelete.Enabled = true;
                btnFind.Enabled = true;
                btnEdit.Enabled = true;
            }


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

        private void dgvTrainRadio_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if ((int)this.dgvTrainRadio.Rows[e.RowIndex].Cells[1].Value == (int)this.dgvTrainRadio.Rows[e.RowIndex].Cells[2].Value)
            //{
            //    this.dgvTrainRadio.Rows[e.RowIndex].Cells[5].Style.BackColor = Color.LightGreen;
            //    this.dgvTrainRadio.Rows[e.RowIndex].Cells[5].Style.SelectionBackColor = Color.LightGreen;
            //    this.dgvTrainRadio.Rows[e.RowIndex].Cells[5].Style.ForeColor = Color.White;
            //}

            //if ((int)this.dgvTrainRadio.Rows[e.RowIndex].Cells[1].Value == (int)this.dgvTrainRadio.Rows[e.RowIndex].Cells[3].Value)
            //{
            //    this.dgvTrainRadio.Rows[e.RowIndex].Cells[6].Style.BackColor = Color.LightGreen;
            //    this.dgvTrainRadio.Rows[e.RowIndex].Cells[6].Style.SelectionBackColor = Color.LightGreen;
            //    this.dgvTrainRadio.Rows[e.RowIndex].Cells[6].Style.ForeColor = Color.White;
            //}
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", this.Text,
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = Int32.Parse(dgvTrainRadio.CurrentRow.Cells["id"].Value.ToString());
                int retVal = MysqlHelper.ExecuteNonQuery("DELETE FROM train_radios where id ='" + id + "'");
                if (retVal == 1)
                {
                    loadGrid();
                }
                else
                {
                    MessageBox.Show("Erorr deleting record.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        

    }
}
