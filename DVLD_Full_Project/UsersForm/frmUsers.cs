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

namespace DVLD_Full_Project
{
    public partial class frmUsers : Form
    {
        private DataTable _PrintDv;
        public frmUsers()
        {
            InitializeComponent();
        }
        private void _RefreshData()
        {
            _PrintDv = clsUser.GetAllUsers();
            dataGridView1.DataSource = _PrintDv;
            labNum.Text = dataGridView1.Rows.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmUsers_Load(object sender, EventArgs e)
        {
            _RefreshData();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex == 0)
            {
                _RefreshData();
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView view = _PrintDv.DefaultView;
            if (textBox1.Text == "" )
            {
                _RefreshData();
                return;
            }
            try
            {
                string filterColumn = cmbFilter.SelectedItem.ToString();
                if (_PrintDv.Columns[filterColumn].DataType == typeof(string))
                {
                    view.RowFilter = $"[{filterColumn}] LIKE '%{textBox1.Text}%'";
                }
                else
                {
                    // For non-string columns, use an equality filter or other appropriate logic
                    if (int.TryParse(textBox1.Text, out int numericValue))
                    {
                        view.RowFilter = $"[{filterColumn}] = {numericValue}";
                    }
                }
            }
            catch (Exception ex)
            {
                _RefreshData();
                MessageBox.Show($"Error filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btAdd_Click(object sender, EventArgs e)
        {
            FrmAddEditUsers frm = new FrmAddEditUsers();
            frm.ShowDialog();
            _RefreshData();
        }

        private void addNewPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FrmAddEditUsers frm = new FrmAddEditUsers();
            frm.ShowDialog();
            _RefreshData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmAddEditUsers frm = new FrmAddEditUsers((int)dataGridView1.CurrentRow.Cells[0].Value);
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
    }
}
