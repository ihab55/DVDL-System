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
    public partial class frmInternationalLicenses : Form
    {
        private DataTable _PrintDv;
        private clsInternationalLicense IntLic ;
        public frmInternationalLicenses()
        {
            InitializeComponent();
        }
        private void _Refresh()
        {
            _PrintDv = BussinessLayer.clsInternationalLicense.GetAllIntLicense();
            dataGridView1.DataSource = _PrintDv;
            labNum.Text = dataGridView1.Rows.Count.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void frmInternationalLicenses_Load(object sender, EventArgs e)
        {
            _Refresh();
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex == 0)
            {
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
            if (textBox1.Text == "")
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
            frmNewInternational newInternational = new frmNewInternational();
            newInternational.ShowDialog();
        }

        private void showPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            IntLic = clsInternationalLicense.Find((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmLicenseHistory frmLicenseHistory = new frmLicenseHistory(IntLic.DriverInfo.PersonInfo.Id);
            frmLicenseHistory.ShowDialog();
        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IntLic = clsInternationalLicense.Find((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmCardDetailsPerson frmCardDetails = new frmCardDetailsPerson(IntLic.DriverInfo.PersonInfo.Id);
            frmCardDetails.ShowDialog();
        }

        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo frmInternationalLicenseInfo = new frmInternationalLicenseInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmInternationalLicenseInfo.ShowDialog();
        }
    }
}
