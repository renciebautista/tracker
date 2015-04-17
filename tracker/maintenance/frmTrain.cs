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

                
            }else
            {
                if (txtCode.Text == "")
                {
                    MessageBox.Show("Code is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtCode.Focus();
                }else if (txtDesc.Text == "")
                {
                    MessageBox.Show("Description is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtDesc.Focus();
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
                //toggleInput(false);
                //btnAdd.Text = "&Add";
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            resetForm();

        }

        private int addTrain()
        {
            return MysqlHelper.ExecuteNonQuery("INSERT INTO trains (train_code,	train_desc,image_index) VALUES(@code, @desc, @image_index)",
                new MySqlParameter("@code",txtCode.Text.Trim()),
                new MySqlParameter("@desc", txtDesc.Text.Trim()),
                new MySqlParameter("@image_index", cmbIcon.SelectedIndex));
        }

        private void loadGrid()
        {
            dgvTrain.AutoGenerateColumns = false;
            bs.DataSource = MysqlHelper.ExecuteDataTable("SELECT * FROM trains");
            bdgNavigator.BindingSource = bs;
            dgvTrain.DataSource = bs;


        }

        private void frmTrain_Load(object sender, EventArgs e)
        {
            loadGrid();
            txtCode.DataBindings.Add(new Binding("Text", bs, "train_code", true));
            txtDesc.DataBindings.Add(new Binding("Text", bs, "train_desc", true));
            cmbIcon.DataBindings.Add(new Binding("SelectedIndex", bs, "image_index", true));
            Image[] images = 
            {
                Properties.Resources.train_green,
                Properties.Resources.train_red,
                Properties.Resources.train_yellow,
                Properties.Resources.train_blue,
                Properties.Resources.train_brown,
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
            if (btnEdit.Text == "&Edit")
            {
                toggleInput(true);
                btnEdit.Text = "&Update";
                btnAdd.Enabled = false;
                btnDelete.Enabled = false;
                btnFind.Enabled = false;
                btnCancel.Enabled = true;
                txtCode.Focus();
            }
            else
            {

                MysqlHelper.ExecuteNonQuery("UPDATE trains SET train_code=@code,train_desc=@desc, image_index=@image_index WHERE id=@id",
                new MySqlParameter("@code", txtCode.Text.Trim()),
                new MySqlParameter("@desc", txtDesc.Text.Trim()),
                 new MySqlParameter("@image_index", cmbIcon.SelectedIndex),
                new MySqlParameter("@id", Convert.ToInt32(dgvTrain.CurrentRow.Cells[0].Value.ToString())));

                resetForm();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", this.Text,
               MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                int id = Int32.Parse(dgvTrain.CurrentRow.Cells["id"].Value.ToString());
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
        }
    }
}
