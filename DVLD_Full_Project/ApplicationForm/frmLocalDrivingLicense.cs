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

namespace DVLD_Full_Project
{
    public partial class frmLocalDrivingLicense : Form
    {
        private DataTable _PrintDv;
        public frmLocalDrivingLicense()
        {
            InitializeComponent();
            _Refresh();
        }
        private void _Refresh()
        {
            _PrintDv = BussinessLayer.clsLocalDrivingLicenseApp.GetAllLocalApp();
            dataGridView1.DataSource = _PrintDv;
            labNum.Text = dataGridView1.Rows.Count.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex == 0)
            {
                _Refresh();
                textBox1.Visible = false;
            }
            else
            {
                textBox1.Visible = true;
            }
            textBox1.Text = string.Empty;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView view = _PrintDv.DefaultView;
            if (textBox1.Text == "" )
            {
                _Refresh();
                return;
            }
            if (cmbFilter.SelectedItem == null)
            {
                MessageBox.Show("Please select a filter first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                labNum.Text = view.Count.ToString();
            }
            catch (Exception ex)
            {
                _Refresh();
                MessageBox.Show($"Error filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseAPP frm = new frmNewLocalDrivingLicenseAPP();
            frm.ShowDialog();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemnt Yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void eDitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemnt Yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemnt Yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void issueDrivingLicToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemnt Yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemnt Yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemnt Yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void canelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (clsLocalDrivingLicenseApp.CancelLocalAppStatus(LocalID))
            {
                MessageBox.Show($"Application {LocalID} Canceled Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Refresh();
            }
            else
            {
                MessageBox.Show($"Application {LocalID} Is Aleady Canceled OR Completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
