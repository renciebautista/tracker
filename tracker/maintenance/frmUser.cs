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
    public partial class frmUser : Form
    {
        BindingSource bs = new BindingSource();
        public frmUser()
        {
            InitializeComponent();
        }

        private void loadGrid()
        {
            if (MysqlHelper.TestConnection())
            {

                dgvUser.AutoGenerateColumns = false;
                bs.DataSource = MysqlHelper.ExecuteDataTable("SELECT users.id,username,group_id,groups.group,active FROM users INNER JOIN groups on users.group_id = groups.id");
                bdgNavigator.BindingSource = bs;
                dgvUser.DataSource = bs;

                if (dgvUser.Rows.Count < 1)
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
            else
            {
                Application.Exit();
            }



        }

        private void toggleInput(bool value)
        {
            txtUsername.Enabled = value;
            txtPassword.Enabled = value;
            txtConfirm.Enabled = value;
            chkActive.Enabled = value;
            cmbGroup.Enabled = value;

            btnClose.Enabled = !value;
            bdgNavigator.Enabled = !value;
            dgvUser.Enabled = !value;

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

        private int addUser()
        {
            string hash = security.GenerateHash(txtPassword.Text.Trim());

            return MysqlHelper.ExecuteNonQuery("INSERT INTO users (username,pwd,group_id, active) VALUES(@username, @pwd, @group_id, @active)",
                new MySqlParameter("@username", txtUsername.Text.Trim().ToUpper()),
                new MySqlParameter("@pwd", hash),
                new MySqlParameter("@group_id", cmbGroup.SelectedValue.ToString()),
                new MySqlParameter("@active", chkActive.Checked ? 1 : 0));
        }

        private int updateUser()
        {
            string hash = security.GenerateHash(txtPassword.Text.Trim());
            return MysqlHelper.ExecuteNonQuery("UPDATE users SET username=@username,pwd=@pwd,group_id=@group_id,active=@active WHERE id=@id",
               new MySqlParameter("@username", txtUsername.Text.Trim().ToUpper()),
               new MySqlParameter("@pwd", hash),
               new MySqlParameter("@group_id", cmbGroup.SelectedValue.ToString()),
               new MySqlParameter("@active", chkActive.Checked ? 1 : 0),
               new MySqlParameter("@id", Convert.ToInt32(dgvUser.CurrentRow.Cells[0].Value.ToString())));
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

                    txtUsername.Text = "";
                    txtPassword.Text = "";
                    txtConfirm.Text = "";

                    txtUsername.Focus();
                }
                else
                {
                    if (txtUsername.Text == "")
                    {
                        MessageBox.Show("Username is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Focus();
                    }
                    else if (txtPassword.Text == "")
                    {
                        MessageBox.Show("Password is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Focus();
                    }
                    else if (txtPassword.Text.Trim() != txtConfirm.Text.Trim())
                    {
                        MessageBox.Show("Password does not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Focus();
                        txtConfirm.Text = "";
                    }
                    else
                    {
                        DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM users where username ='" + txtUsername.Text.Trim().ToUpper() + "'");
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Username already exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsername.Focus();
                            txtPassword.Text = "";
                            txtConfirm.Text = "";
                        }
                        else
                        {
                            if (addUser() == 1)
                            {
                                resetForm();

                                dgvUser.ClearSelection();//If you want

                                int nRowIndex = dgvUser.Rows.Count - 1;
                                int nColumnIndex = 3;

                                dgvUser.Rows[nRowIndex].Selected = true;
                                dgvUser.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

                                //In case if you want to scroll down as well.
                                dgvUser.FirstDisplayedScrollingRowIndex = nRowIndex;
                            }
                            else
                            {
                                MessageBox.Show("Unable to save user.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtUsername.Focus();
                            }
                            //MessageBox.Show(addTrain().ToString());
                            resetForm();
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
        }

        private void frmUser_Load(object sender, EventArgs e)
        {
            if (MysqlHelper.TestConnection())
            {
                loadGrid();

                txtUsername.DataBindings.Add(new Binding("Text", bs, "username", true));
                cmbGroup.DataBindings.Add(new Binding("SelectedValue", bs, "group_id", true));
                chkActive.DataBindings.Add(new Binding("Checked", bs, "active", true));

                cmbGroup.ValueMember = "id";
                cmbGroup.DisplayMember = "group";
                cmbGroup.DataSource = MysqlHelper.ExecuteDataTable("SELECT * FROM groups");
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
                    int id = Int32.Parse(dgvUser.CurrentRow.Cells["id"].Value.ToString());
                    int retVal = MysqlHelper.ExecuteNonQuery("DELETE FROM users where id ='" + id + "'");
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
                DataTable dt = MysqlHelper.ExecuteDataTable("SELECT users.id,username,groups.group FROM users INNER JOIN groups on users.group_id = groups.id");

                string[] fields = new string[] { "ID", "USERNAME", "GROUP", };
                string[] field_ids = new string[] { "id", "username", "group" };
                int[] fieldsSize = new int[] { 50, 300, 300 };

                frmFind frmFind = new frmFind();
                frmFind.DataSource = dt;
                frmFind.SearchFor = "Users";
                frmFind.FieldId = "id";
                frmFind.Fields = fields;
                frmFind.FieldIds = field_ids;
                frmFind.FieldsSize = fieldsSize;

                if (frmFind.ShowDialog() == DialogResult.OK)
                {
                    result = frmFind.FilterValue;
                    loadGrid();
                    frmFind.MoveCursor(result, dgvUser);
                }
                frmFind.Dispose();
                btnAdd.Focus();
            }
            else
            {
                Application.Exit();
            }
            
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
                    txtUsername.Focus();

                }
                else
                {
                    if (txtUsername.Text == "")
                    {
                        MessageBox.Show("Username is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtUsername.Focus();
                    }
                    else if (txtPassword.Text == "")
                    {
                        MessageBox.Show("Password is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Focus();
                    }
                    else if (txtPassword.Text.Trim() != txtConfirm.Text.Trim())
                    {
                        MessageBox.Show("Password does not match!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtPassword.Focus();
                        txtConfirm.Text = "";
                    }
                    else
                    {
                        DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM users where username ='" + txtUsername.Text.Trim().ToUpper() + "' AND id != '" + Convert.ToInt32(dgvUser.CurrentRow.Cells[0].Value.ToString()) + "'");
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Username already exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtUsername.Focus();
                            txtPassword.Text = "";
                            txtConfirm.Text = "";
                        }
                        else
                        {
                            if (updateUser() == 1)
                            {
                                resetForm();
                            }
                            else
                            {
                                MessageBox.Show("Unable to save user.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtUsername.Focus();
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

        private void s_Enter(object sender, EventArgs e)
        {

        }
    }
}
