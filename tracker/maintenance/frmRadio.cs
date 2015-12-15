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
        Image[] images = 
            {
                Properties.Resources.BLUE_HILITED,
                Properties.Resources.RED_HILITED,
                Properties.Resources.FIRE_BLUE_HILITED,
                Properties.Resources.FIRE_GREY_HILITED,
                Properties.Resources.FIRE_RED_HILITED,
                Properties.Resources.INDIE_BLUE_HILITED,
                Properties.Resources.INDIE_GREY_HILITED,
                Properties.Resources.INDIE_RED_HILITED,
                Properties.Resources.MEDIC_BLUE_HILITED,
                Properties.Resources.MEDIC_GREY_HILITED,
                Properties.Resources.MEDIC_RED_HILITED,
                Properties.Resources.PET_BLUE_HILITED,
                Properties.Resources.PET_GREY_HILITED,
                Properties.Resources.PET_RED_HILITED,
                Properties.Resources.POLICE_BLUE_HILITED,
                Properties.Resources.POLICE_GREY_HILITED,
                Properties.Resources.POLICE_RED_HILITED,
                Properties.Resources.VEHICLE_BLUE_HILITED,
                Properties.Resources.VEHICLE_GRE_HILITED,
                Properties.Resources.VEHICLE_RED_HILITED,
                Properties.Resources.b_unit1,
                Properties.Resources.b_unit2,
                Properties.Resources.b_unit3,
                Properties.Resources.b_unit4,
                Properties.Resources.b_unit5,
                Properties.Resources.b_unit6,
                Properties.Resources.b_unit7,
                Properties.Resources.b_unit8,
                Properties.Resources.b_unit9,
                Properties.Resources.b_unit10,
                Properties.Resources.b_unit11,
                Properties.Resources.b_unit12,
                Properties.Resources.b_unit13,
                Properties.Resources.b_unit14,
                Properties.Resources.b_unit15,
                Properties.Resources.b_unit16,
                Properties.Resources.b_unit17,
                Properties.Resources.b_unit18,
                Properties.Resources.b_unit19,
                Properties.Resources.b_unit20,
                Properties.Resources.g_unit1,
                Properties.Resources.g_unit2,
                Properties.Resources.g_unit3,
                Properties.Resources.g_unit4,
                Properties.Resources.g_unit5,
                Properties.Resources.g_unit6,
                Properties.Resources.g_unit7,
                Properties.Resources.g_unit8,
                Properties.Resources.g_unit9,
                Properties.Resources.g_unit10,
                Properties.Resources.g_unit11,
                Properties.Resources.g_unit12,
                Properties.Resources.g_unit13,
                Properties.Resources.g_unit14,
                Properties.Resources.g_unit15,
                Properties.Resources.g_unit16,
                Properties.Resources.g_unit17,
                Properties.Resources.g_unit18,
                Properties.Resources.g_unit19,
                Properties.Resources.g_unit20,
                Properties.Resources.r_unit1,
                Properties.Resources.r_unit2,
                Properties.Resources.r_unit3,
                Properties.Resources.r_unit4,
                Properties.Resources.r_unit5,
                Properties.Resources.r_unit6,
                Properties.Resources.r_unit7,
                Properties.Resources.r_unit8,
                Properties.Resources.r_unit9,
                Properties.Resources.r_unit10,
                Properties.Resources.r_unit11,
                Properties.Resources.r_unit12,
                Properties.Resources.r_unit13,
                Properties.Resources.r_unit14,
                Properties.Resources.r_unit15,
                Properties.Resources.r_unit16,
                Properties.Resources.r_unit17,
                Properties.Resources.r_unit18,
                Properties.Resources.r_unit19,
                Properties.Resources.r_unit20,
            };
        public frmRadio()
        {
            InitializeComponent();
        }
        private void loadGrid()
        {
            if (MysqlHelper.TestConnection())
            {
                dgvRadio.AutoGenerateColumns = false;
                bs.DataSource = MysqlHelper.ExecuteDataTable("SELECT * FROM radios");
                bdgNavigator.BindingSource = bs;
                dgvRadio.DataSource = bs;
                if (dgvRadio.Rows.Count < 1)
                {
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnFind.Enabled = false;
                }
            }
            else
            {
                Application.Exit();
            }
        }
        private void toggleInput(bool value)
        {
            txtMcc.Enabled = value;
            txtMnc.Enabled = value;
            txtSsi.Enabled = value;
            txtTrackerCode.Enabled = value;
            chkActive.Enabled = value;
            cmbIcon.Enabled = value;

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
            chkRange.Enabled = false;
            chkRange.Checked = false;

            loadGrid();
        }

        private int addRadio()
        {
            return MysqlHelper.ExecuteNonQuery("INSERT INTO radios (mcc, mnc, ssi, tracker_code, image_index, active) VALUES(@mcc, @mnc, @ssi, @tracker_code, @image_index, @active)",
                new MySqlParameter("@mcc", txtMcc.Text.Trim()),
                new MySqlParameter("@mnc", txtMnc.Text.Trim()),
                new MySqlParameter("@ssi", txtSsi.Text.Trim()),
                new MySqlParameter("@tracker_code", txtTrackerCode.Text.Trim()),
                new MySqlParameter("@image_index", cmbIcon.SelectedIndex),
                new MySqlParameter("@active", chkActive.Checked ? 1 : 0));
        }

        private int updateRadio()
        {
            return MysqlHelper.ExecuteNonQuery("UPDATE radios SET mcc=@mcc,mnc=@mnc,ssi=@ssi,tracker_code=@tracker_code,image_index=@image_index,active=@active WHERE id=@id",
                new MySqlParameter("@mcc", txtMcc.Text.Trim()),
                new MySqlParameter("@mnc", txtMnc.Text.Trim()),
                new MySqlParameter("@ssi", txtSsi.Text.Trim()),
                new MySqlParameter("@tracker_code", txtTrackerCode.Text.Trim()),
                new MySqlParameter("@image_index", cmbIcon.SelectedIndex),
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
            cmbIcon.DataBindings.Add(new Binding("SelectedIndex", bs, "image_index", true));
           

            cmbIcon.DisplayImages(images);
            cmbIcon.SelectedIndex = 0;
            cmbIcon.DropDownHeight = 200;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (MysqlHelper.TestConnection())
            {
                if (btnAdd.Text == "&Add")
                {
                    toggleInput(true);
                    btnAdd.Text = "&Save";
                    btnEdit.Enabled = false;
                    btnDelete.Enabled = false;
                    btnFind.Enabled = false;
                    btnCancel.Enabled = true;
                    chkRange.Enabled = true;

                    txtMcc.Text = "";
                    txtMnc.Text = "";
                    txtSsi.Text = "";
                    txtTrackerCode.Text = "";
                    txtMcc.Focus();

                }
                else
                {

                    if (chkRange.Checked)
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
                        else if (txtFrom.Text == "")
                        {
                            MessageBox.Show("Range from is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtFrom.Focus();
                        }
                        else if (txtTo.Text == "")
                        {
                            MessageBox.Show("Range to is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTo.Focus();
                        }
                        else if (Convert.ToInt32(txtFrom.Text) >= Convert.ToInt32(txtTo.Text))
                        {
                            MessageBox.Show("Range is invalid!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtTo.Focus();
                        }
                        else
                        {
                            for (int i = Convert.ToInt32(txtFrom.Text); i <= Convert.ToInt32(txtTo.Text); i++)
                            {
                                DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM radios where ssi ='" + i.ToString() + "'");
                                if (dt.Rows.Count > 0)
                                {
                                    MessageBox.Show("Radio Ssi '" + i.ToString() + "' already exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    //txtSsi.Focus();
                                }
                                else
                                {
                                    MysqlHelper.ExecuteNonQuery("INSERT INTO radios (mcc, mnc, ssi, tracker_code, image_index, active) VALUES(@mcc, @mnc, @ssi, @tracker_code, @image_index, @active)",
                                   new MySqlParameter("@mcc", txtMcc.Text.Trim()),
                                   new MySqlParameter("@mnc", txtMnc.Text.Trim()),
                                   new MySqlParameter("@ssi", i.ToString()),
                                   new MySqlParameter("@tracker_code", ""),
                                   new MySqlParameter("@image_index", cmbIcon.SelectedIndex),
                                   new MySqlParameter("@active", chkActive.Checked ? 1 : 0));
                                }

                            }


                            resetForm();
                            txtSsi.Enabled = false;
                            txtTrackerCode.Enabled = false;
                        }
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
                            DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM radios where ssi ='" + txtSsi.Text.Trim() + "'");
                            if (dt.Rows.Count > 0)
                            {
                                MessageBox.Show("Radio Ssi already exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                        }
                    }

                }
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetForm();
            chkRange.Enabled = false;
            txtSsi.Enabled = false;
            txtTrackerCode.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MysqlHelper.TestConnection())
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
            else
            {
                Application.Exit();
            }
            
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            if (MysqlHelper.TestConnection())
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
            else
            {
                Application.Exit();
            }
            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MysqlHelper.TestConnection())
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
            else
            {
                Application.Exit();
            }
            
        }

        private void chkRange_CheckedChanged(object sender, EventArgs e)
        {
            if (chkRange.Checked == true)
            {
                txtSsi.Enabled = false;
                txtFrom.Enabled = true;
                txtTo.Enabled = true;
                txtTrackerCode.Enabled = false;
            }
            else
            {
                txtSsi.Enabled = true;
                txtFrom.Enabled = false;
                txtTo.Enabled = false;
                txtFrom.Text = "";
                txtTo.Text = "";
                txtTrackerCode.Enabled = true;
            }
        }

        private void txtFrom_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtTo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
    }
}
