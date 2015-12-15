using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using tracker.Properties;
using System.Resources;
using System.Globalization;
using System.Collections;

namespace tracker.maintenance
{
    public partial class frmTrain : Form
    {
        BindingSource bs = new BindingSource();   
        public frmTrain()
        {
            InitializeComponent();
        }

        private void toggleInput(bool value)
        {
            txtCode.Enabled = value;
            txtDesc.Enabled = value;
            chkActive.Enabled = value;
            cmbIcon.Enabled = value;

            btnClose.Enabled = !value;
            bdgNavigator.Enabled = !value;
            dgvTrain.Enabled = !value;

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

                    txtCode.Text = "";
                    txtDesc.Text = "";
                    txtCode.Focus();


                }
                else
                {
                    if (txtCode.Text == "")
                    {
                        MessageBox.Show("Code is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtCode.Focus();
                    }
                    else if (txtDesc.Text == "")
                    {
                        MessageBox.Show("Description is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtDesc.Focus();
                    }
                    else
                    {
                        DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM trains where train_code ='" + txtCode.Text.Trim() + "'");
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Train code already exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtCode.Focus();
                        }
                        else
                        {
                            if (addTrain() == 1)
                            {
                                resetForm();

                                dgvTrain.ClearSelection();//If you want

                                int nRowIndex = dgvTrain.Rows.Count - 1;
                                int nColumnIndex = 3;

                                dgvTrain.Rows[nRowIndex].Selected = true;
                                dgvTrain.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

                                //In case if you want to scroll down as well.
                                dgvTrain.FirstDisplayedScrollingRowIndex = nRowIndex;
                            }
                            else
                            {
                                MessageBox.Show("Unable to save transaction!", "Transaction Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtCode.Focus();
                            }
                            //MessageBox.Show(addTrain().ToString());
                            resetForm();
                        }

                    }
                    //toggleInput(false);
                    //btnAdd.Text = "&Add";
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

        }

        private int addTrain()
        {
            return MysqlHelper.ExecuteNonQuery("INSERT INTO trains (train_code,	train_desc,image_index, active) VALUES(@code, @desc, @image_index, @active)",
                new MySqlParameter("@code",txtCode.Text.Trim()),
                new MySqlParameter("@desc", txtDesc.Text.Trim()),
                new MySqlParameter("@image_index", cmbIcon.SelectedIndex),
                new MySqlParameter("@active", chkActive.Checked ? 1 : 0));
        }

        private void loadGrid()
        {
            if (MysqlHelper.TestConnection())
            {
                dgvTrain.AutoGenerateColumns = false;
                bs.DataSource = MysqlHelper.ExecuteDataTable("SELECT * FROM trains");
                bdgNavigator.BindingSource = bs;
                dgvTrain.DataSource = bs;
            }
            else
            {
                Application.Exit();
            }
        }

        private void frmTrain_Load(object sender, EventArgs e)
        {
            loadGrid();
            txtCode.DataBindings.Add(new Binding("Text", bs, "train_code", true));
            txtDesc.DataBindings.Add(new Binding("Text", bs, "train_desc", true));
            cmbIcon.DataBindings.Add(new Binding("SelectedIndex", bs, "image_index", true));
            chkActive.DataBindings.Add(new Binding("Checked", bs, "active", true));
            Image[] images = 
            {
                Properties.Resources.train_green,
                Properties.Resources.train_red,
                Properties.Resources.train_yellow,
                Properties.Resources.train_blue,
                Properties.Resources.train_brown,
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

            cmbIcon.DisplayImages(images);
            cmbIcon.SelectedIndex = 0;
            cmbIcon.DropDownHeight = 200;

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
                    txtCode.Focus();
                    int id = Int32.Parse(dgvTrain.CurrentRow.Cells["id"].Value.ToString());
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

                    MysqlHelper.ExecuteNonQuery("UPDATE trains SET train_code=@code,train_desc=@desc, image_index=@image_index, active=@active WHERE id=@id",
                    new MySqlParameter("@code", txtCode.Text.Trim()),
                    new MySqlParameter("@desc", txtDesc.Text.Trim()),
                    new MySqlParameter("@image_index", cmbIcon.SelectedIndex),
                    new MySqlParameter("@active", chkActive.Checked ? 1 : 0),
                    new MySqlParameter("@id", Convert.ToInt32(dgvTrain.CurrentRow.Cells[0].Value.ToString())));

                    resetForm();
                }
            }
            else
            {
                Application.Exit();
            }
            
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MysqlHelper.TestConnection())
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", this.Text,
                MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    int id = Int32.Parse(dgvTrain.CurrentRow.Cells["id"].Value.ToString());
                    DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM train_radios WHERE train_id ='" + id + "'");
                    if (dt.Rows.Count == 0)
                    {
                        int retVal = MysqlHelper.ExecuteNonQuery("DELETE FROM trains where id ='" + id + "'");
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
                        MessageBox.Show("Cannot delete train it is currently assigned with a radio.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataTable dt = MysqlHelper.ExecuteDataTable("SELECT id, train_code, train_desc FROM trains");

                string[] fields = new string[] { "ID", "CODE", "DESCRIPTION" };
                string[] field_ids = new string[] { "id", "train_code", "train_desc" };
                int[] fieldsSize = new int[] { 50, 100, 400 };

                frmFind frmFind = new frmFind();
                frmFind.DataSource = dt;
                frmFind.SearchFor = "Trains";
                frmFind.FieldId = "id";
                frmFind.Fields = fields;
                frmFind.FieldIds = field_ids;
                frmFind.FieldsSize = fieldsSize;

                if (frmFind.ShowDialog() == DialogResult.OK)
                {
                    result = frmFind.FilterValue;
                    loadGrid();
                    frmFind.MoveCursor(result, dgvTrain);
                }
                frmFind.Dispose();
                btnAdd.Focus();
            }
            else
            {
                Application.Exit();
            }
            
        }
    }
}
