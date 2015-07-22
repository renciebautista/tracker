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
    public partial class frmServer : Form
    {
        BindingSource bs = new BindingSource();
        public frmServer()
        {
            InitializeComponent();
        }

        private void toggleInput(bool value)
        {
            txtIpAddress.Enabled = value;

            btnClose.Enabled = !value;
            bdgNavigator.Enabled = !value;
            dgvServers.Enabled = !value;

        }

        private int addServer()
        {
            return MysqlHelper.ExecuteNonQuery("INSERT INTO servers (ip) VALUES(@ip)",
                new MySqlParameter("@ip", txtIpAddress.Text.Trim().ToUpper()));
        }
        private int updateServer()
        {
            return MysqlHelper.ExecuteNonQuery("UPDATE servers SET ip=@ip WHERE id=@id",
                new MySqlParameter("@ip", txtIpAddress.Text.Trim().ToUpper()),
                new MySqlParameter("@id", Convert.ToInt32(dgvServers.CurrentRow.Cells[0].Value.ToString())));
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

        private void loadGrid()
        {
            if (MysqlHelper.TestConnection())
            {
                dgvServers.AutoGenerateColumns = false;
                bs.DataSource = MysqlHelper.ExecuteDataTable("SELECT * from servers");
                bdgNavigator.BindingSource = bs;
                dgvServers.DataSource = bs;

                if (dgvServers.Rows.Count < 1)
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

                    txtIpAddress.Text = "";
                    txtIpAddress.Focus();
                }
                else
                {
                    if (txtIpAddress.Text == "")
                    {
                        MessageBox.Show("Server Ip Address is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIpAddress.Focus();
                    }
                    else
                    {
                        DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM servers where ip ='" + txtIpAddress.Text.Trim().ToUpper() + "'");
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Username already exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtIpAddress.Focus();
                            txtIpAddress.Text = "";
                        }
                        else
                        {
                            if (addServer() == 1)
                            {
                                resetForm();

                                dgvServers.ClearSelection();//If you want

                                int nRowIndex = dgvServers.Rows.Count - 1;
                                int nColumnIndex = 1;

                                dgvServers.Rows[nRowIndex].Selected = true;
                                dgvServers.Rows[nRowIndex].Cells[nColumnIndex].Selected = true;

                                //In case if you want to scroll down as well.
                                dgvServers.FirstDisplayedScrollingRowIndex = nRowIndex;
                            }
                            else
                            {
                                MessageBox.Show("Unable to add new radio server.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtIpAddress.Focus();
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
                    txtIpAddress.Focus();

                }
                else
                {
                    if (txtIpAddress.Text == "")
                    {
                        MessageBox.Show("Server Ip Address is required!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtIpAddress.Focus();
                    }
                    else
                    {
                        DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * FROM servers where ip ='" + txtIpAddress.Text.Trim().ToUpper() + "' AND id != '" + Convert.ToInt32(dgvServers.CurrentRow.Cells[0].Value.ToString()) + "'");
                        if (dt.Rows.Count > 0)
                        {
                            MessageBox.Show("Server Name already exist.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtIpAddress.Focus();
                            txtIpAddress.Text = "";
                        }
                        else
                        {
                            if (updateServer() == 1)
                            {
                                resetForm();
                            }
                            else
                            {
                                MessageBox.Show("Unable to udpate server.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtIpAddress.Focus();
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

        private void frmServer_Load(object sender, EventArgs e)
        {
            if (MysqlHelper.TestConnection())
            {
                loadGrid();
                txtIpAddress.DataBindings.Add(new Binding("Text", bs, "ip", true));
 
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
                    int id = Int32.Parse(dgvServers.CurrentRow.Cells["id"].Value.ToString());
                    int retVal = MysqlHelper.ExecuteNonQuery("DELETE FROM servers where id ='" + id + "'");
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
                DataTable dt = MysqlHelper.ExecuteDataTable("SELECT * from servers");

                string[] fields = new string[] { "ID", "Ip Address", };
                string[] field_ids = new string[] { "id", "ip" };
                int[] fieldsSize = new int[] { 50, 600 };

                frmFind frmFind = new frmFind();
                frmFind.DataSource = dt;
                frmFind.SearchFor = "Radio Servers";
                frmFind.FieldId = "id";
                frmFind.Fields = fields;
                frmFind.FieldIds = field_ids;
                frmFind.FieldsSize = fieldsSize;

                if (frmFind.ShowDialog() == DialogResult.OK)
                {
                    result = frmFind.FilterValue;
                    loadGrid();
                    frmFind.MoveCursor(result, dgvServers);
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
