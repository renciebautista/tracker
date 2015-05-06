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
            bs.DataSource = MysqlHelper.ExecuteDataTable("SELECT train_radios.train_id as id,trains.train_code,trains.train_desc,radios.mcc,radios.mnc,radios.ssi,radios.tracker_code,"+
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
            using (frmAddTrain addTrain = new frmAddTrain(frmAddTrain.FormMode.Add))
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
                DataTable list = MysqlHelper.ExecuteDataTable("SELECT id FROM train_radios WHERE train_id = '" + id + "'");
                int retVal = 0;
                if (list.Rows.Count > 0)
                {
                    foreach (DataRow dr in list.Rows)
                    {
                        retVal = MysqlHelper.ExecuteNonQuery("DELETE FROM train_radios WHERE id = '" + dr["id"].ToString() + "'");
                    }
                }
                //int retVal = MysqlHelper.ExecuteNonQuery("DELETE FROM train_radios WHERE id IN (SELECT cid FROM (SELECT id as cid FROM train_radios WHERE train_id = '" + id + "') as c)");
                if (retVal > 0)
                {
                    loadGrid();
                }
                else
                {
                    MessageBox.Show("Erorr deleting record.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int result;
            DataTable dt = MysqlHelper.ExecuteDataTable("SELECT train_radios.train_id as id,trains.train_code,trains.train_desc,radios.ssi," +
                "tbl2.head_ssi" +
                " FROM train_radios " +
                " INNER JOIN trains on train_radios.train_id = trains.id" +
                " INNER JOIN radios on train_radios.radio_id = radios.id" +
                " inner join (" +
                " SELECT train_radios.train_id, radios.mcc as head_mcc,radios.mnc as head_mnc,radios.ssi as head_ssi,radios.tracker_code as head_tracker_code FROM train_radios" +
                " INNER JOIN radios on train_radios.radio_id = radios.id" +
                " WHERE train_radios.head = 1" +
                ")as tbl2 on train_radios.train_id = tbl2.train_id" +
                " WHERE train_radios.head = 0");

            string[] fields = new string[] { "ID", "CODE", "DESCRIPTION", "TAIL", "HEAD" };
            string[] field_ids = new string[] { "id", "train_code", "train_desc", "ssi", "head_ssi" };
            int[] fieldsSize = new int[] { 50, 100, 200, 200, 200 };

            frmFind frmFind = new frmFind();
            frmFind.DataSource = dt;
            frmFind.SearchFor = "Train Radio Assignment";
            frmFind.FieldId = "id";
            frmFind.Fields = fields;
            frmFind.FieldIds = field_ids;
            frmFind.FieldsSize = fieldsSize;

            if (frmFind.ShowDialog() == DialogResult.OK)
            {
                result = frmFind.FilterValue;
                loadGrid();
                frmFind.MoveCursor(result, dgvTrainRadio);
            }
            frmFind.Dispose();
            btnAdd.Focus();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            using (frmAddTrain addTrain = new frmAddTrain(frmAddTrain.FormMode.Edit))
            {
                addTrain.TrainId = (int)dgvTrainRadio.CurrentRow.Cells["id"].Value;
                addTrain.ShowDialog();
            }

            loadGrid();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
        }


        

    }
}
