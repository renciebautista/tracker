using MySql.Data.MySqlClient;
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
    public partial class frmRadio : Form
    {
        BindingSource bs = new BindingSource();
        public frmRadio()
        {
            InitializeComponent();
        }
        private void loadGrid()
        {
            dgvRadio.AutoGenerateColumns = false;
            bs.DataSource = MysqlHelper.ExecuteDataTable("SELECT * FROM radios");
            bdgNavigator.BindingSource = bs;
            dgvRadio.DataSource = bs;


        }
        private void toggleInput(bool value)
        {
            txtMcc.Enabled = value;
            txtMnc.Enabled = value;
            txtSsi.Enabled = value;
            txtTrackerCode.Enabled = value;
            chkActive.Enabled = value;

            btnClose.Enabled = !value;
            bdgNavigator.Enabled = !value;
            dgvRadio.Enabled = !value;

        }

        private void resetForm()
        {
            toggleInput(false);
            btnAdd.Text = "&Add";
            btnAdd.Enabled = true;
            btnEdit.Enabled = true;
            btnEdit.Text = "&Edit";
            btnDelete.Enabled = true;
            btnFind.Enabled = true;
            btnCancel.Enabled = false;

            loadGrid();
        }

        private int addRadio()
        {

            return MysqlHelper.ExecuteNonQuery("INSERT INTO radios (mcc, mnc, ssi, tracker_code, active) VALUES(@mcc, @mnc, @ssi, @tracker_code, @active)",
                new MySqlParameter("@mcc", txtMcc.Text.Trim()),
                new MySqlParameter("@mnc", txtMnc.Text.Trim()),
                new MySqlParameter("@ssi", txtSsi.Text.Trim()),
                new MySqlParameter("@tracker_code", txtTrackerCode.Text.Trim()),
                new MySqlParameter("@active", chkActive.Checked ? 1 : 0));
        }

        private int updateRadio()
        {
             return MysqlHelper.ExecuteNonQuery("UPDATE radios SET mcc=@mcc,mnc=@mnc,ssi=@ssi,tracker_code=@tracker_code,active=@active WHERE id=@id",
                new MySqlParameter("@mcc", txtMcc.Text.Trim()),
                new MySqlParameter("@mnc", txtMnc.Text.Trim()),
                new MySqlParameter("@ssi", txtSsi.Text.Trim()),
                new MySqlParameter("@tracker_code", txtTrackerCode.Text.Trim()),
                new MySqlParameter("@active", chkActive.Checked ? 1 : 0),
                new MySqlParameter("@id", Convert.ToInt32(dgvRadio.CurrentRow.Cells[0].Value.ToString())));
        }

        private void frmRadio_Load(object sender, EventArgs e)
        {
            loadGrid();
            txtMcc.DataBindings.Add(new Binding("Text", bs, "mcc", true));
            txtMnc.DataBindings.Add(new Binding("Text", bs, "mnc", true));
            txtSsi.DataBindings.Add(new Binding("Text", bs, "ssi", true));
            txtTrackerCode.DataBindings.Add(new Binding("Text", bs, "tracker_code", true));
            chkActive.DataBindings.Add(new Binding("Checked", bs, "active", true));
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (btnAdd.Text == "&Add")
            {
                toggleInput(true);
                btnAdd.Text = "&Save";
                btnEdit.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnCancel.Enabled = true;

                txtMcc.Text = "";
                txtMnc.Text = "";
                txtSsi.Text = "";
                txtTrackerCode.Text = "";
                txtMcc.Focus();

            }
            else
            {
                if (txtMcc.Text == "")
                {
                    MessageBox.Show("Radio Mcc is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMcc.Focus();
                }
                else if (txtMnc.Text == "")
                {
                    MessageBox.Show("Radio Mnc is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMnc.Focus();
                }
                else if (txtSsi.Text == "")
                {
                    MessageBox.Show("Radio Ssi is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtSsi.Focus();
                }
                else
                {
                    if (addRadio() == 1)
                    {
                        resetForm();

                        dgvRadio.ClearSelection();//If you want

                        int nRowIndex = dgvRadio.Rows.Count - 1;
                        int nColumnIndex = 3;

                        dgvRadio.Rows[nRowIndex].Selected = true;
                        dgvRadio.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

                        //In case if you want to scroll down as well.
                        dgvRadio.FirstDisplayedScrollingRowIndex = nRowIndex;
                    }
                    else
                    {
                        MessageBox.Show("Unable to save transaction!", "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtMcc.Focus();
                    }
                    //MessageBox.Show(addTrain().ToString());
                    resetForm();
                }
                //toggleInput(false);
                //btnAdd.Text = "&Add";
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetForm();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (btnEdit.Text == "&Edit")
            {
                toggleInput(true);
                btnEdit.Text = "&Update";
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnCancel.Enabled = true;
                txtMcc.Focus();
                int id = Int32.Parse(dgvRadio.CurrentRow.Cells["id"].Value.ToString());
                DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM train_radios WHERE radio_id ='" + id + "'");
                if (dt.Rows.Count > 0)
                {
                    chkActive.Enabled = false;
                }
                else
                {
                    chkActive.Enabled = true;
                }
            }
            else
            {

                if (updateRadio() == 1)
                {
                    resetForm();
                }
                else
                {
                    MessageBox.Show("Unable to save radio!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtMcc.Focus();
                }
            }
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int result;
            DataTable dt = MysqlHelper.ExecuteDataTable("SELECT id, mcc, mnc, ssi, tracker_code FROM radios");

            string[] fields = new string[] { "ID", "MCC", "MNC", "SSI", "TRACKER CODE" };
            string[] field_ids = new string[] { "id", "mcc", "mnc", "ssi", "tracker_code" };
            int[] fieldsSize = new int[] { 50, 100, 100, 200, 200 };

            frmFind frmFind = new frmFind();
            frmFind.DataSource = dt;
            frmFind.SearchFor = "Radios";
            frmFind.FieldId = "id";
            frmFind.Fields = fields;
            frmFind.FieldIds = field_ids;
            frmFind.FieldsSize = fieldsSize;

            if (frmFind.ShowDialog() == DialogResult.OK)
            {
                result = frmFind.FilterValue;
                loadGrid();
                frmFind.MoveCursor(result, dgvRadio);
            }
            frmFind.Dispose();
            btnAdd.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", this.Text,
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = Int32.Parse(dgvRadio.CurrentRow.Cells["id"].Value.ToString());
                DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM train_radios WHERE radio_id ='" + id + "'");
                if (dt.Rows.Count == 0)
                {
                    int retVal = MysqlHelper.ExecuteNonQuery("DELETE FROM radios where id ='" + id + "'");
                    if (retVal == 1)
                    {
                        loadGrid();
                    }
                    else
                    {
                        MessageBox.Show("Erorr deleting record.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Cannot delete radio it is currently assigned to a train.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
            }
        }
    }
}
