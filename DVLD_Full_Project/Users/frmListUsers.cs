using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;
using DVLD_Full_Project.Use_Controller;
using DVLD_Full_Project.UsersForm;

namespace DVLD_Full_Project
{
    public partial class frmListUsers : Form
    {
        private DataTable _dtAllUsers;
        public frmListUsers()
        {
            InitializeComponent();
        }
        private void _RefreshData()
        {
            _dtAllUsers = clsUser.GetAllUsers();
            dataGridView1.DataSource = _dtAllUsers;
            labNum.Text = dataGridView1.Rows.Count.ToString();
        }
        private void frmUsers_Load(object sender, EventArgs e)
        {
            cmbFilter.SelectedIndex  = 0;
            // By defult will Refresh Data becouse the filter is not selected

            dataGridView1.Columns[0].HeaderText = "User ID";
            dataGridView1.Columns[0].Width = 100;

            dataGridView1.Columns[1].HeaderText = "Person ID";
            dataGridView1.Columns[1].Width = 100;

            dataGridView1.Columns[2].HeaderText = "Full Name";
            dataGridView1.Columns[2].Width = 350;

            dataGridView1.Columns[3].HeaderText = "UserName";
            dataGridView1.Columns[3].Width = 120;

            dataGridView1.Columns[4].HeaderText = "Is Active";
            dataGridView1.Columns[4].Width = 120;
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex == 0)
            {
                _RefreshData();
                textBox1.Visible = false;
            }
            else if (cmbFilter.SelectedIndex == 5)
            {
                textBox1.Visible = false;
                combActive.Visible = true;
                combActive.SelectedIndex = 0;
                _RefreshData();
            }
            else 
            {
                textBox1.Visible = true;
                combActive.Visible = false;
            }
            textBox1.Text = string.Empty;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn;
            switch (cmbFilter.Text)
            {
                case "User ID":
                    FilterColumn = "UserID";
                    break;
                case "UserName":
                    FilterColumn = "UserName";
                    break;

                case "Person ID":
                    FilterColumn = "PersonID";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }
            //Reset the filters in case nothing selected or filter value conains nothing.
            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                _RefreshData();
                return;
            }
            
            if (FilterColumn != "FullName" && FilterColumn != "UserName")
                //in this case we deal with numbers not string.
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                _dtAllUsers.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            labNum.Text = dataGridView1.Rows.Count.ToString();
        }
        private void combActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            string FilteredValue = combActive.Text;
            switch (FilteredValue)
            {
                case "All":
                    break;
                case "Yes":
                    FilteredValue = "1";
                    break;
                case "No":
                    FilteredValue = "0";
                    break;
            }

            _dtAllUsers.DefaultView.RowFilter = (FilteredValue == "All") ? "" : string.Format("[{0}] = {1}", "IsActive", FilteredValue);
            labNum.Text = dataGridView1.Rows.Count.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddEditUsers frm = new frmAddEditUsers();
            frm.ShowDialog();
            _RefreshData();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditUsers frm = new frmAddEditUsers((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreshData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUser.DeleteUsers((int)dataGridView1.CurrentRow.Cells[0].Value))
            {
                MessageBox.Show("User Delete succesfull", "Done", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
            else
            {
                MessageBox.Show("User Delete failed have connect Data", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _RefreshData();
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo frm = new frmUserInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword frm = new frmChangePassword((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.SelectedIndex ==1 || cmbFilter.SelectedIndex == 3)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
    }
}
