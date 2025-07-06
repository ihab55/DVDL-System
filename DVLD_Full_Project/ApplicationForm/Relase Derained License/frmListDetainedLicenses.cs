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
    public partial class frmListDetainedLicenses : Form
    {
        private DataTable _PrintDv;
        public frmListDetainedLicenses()
        {
            InitializeComponent();
            _RefreshDataGridView();
        }
        private void _RefreshDataGridView()
        {
            _PrintDv = clsDetainedLicenses.GetAllDetainLicese();
            dataGridView1.DataSource = _PrintDv;
            labNum.Text = dataGridView1.RowCount.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex != 0)
            {
                _RefreshDataGridView();
                textBox1.Visible = true;
            }
            else
            {
                textBox1.Visible = false;
            }
            textBox1.Text = string.Empty;
        }
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if ((bool)dataGridView1.CurrentRow.Cells[3].Value)
            {
                relaseDetaiToolStripMenuItem.Enabled = false;
            }
            else
            {
                relaseDetaiToolStripMenuItem.Enabled = true;
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView view = _PrintDv.DefaultView;
            if (textBox1.Text == "")
            {
                _RefreshDataGridView();
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
               _RefreshDataGridView();
                MessageBox.Show($"Error filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void showPersonDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((string)dataGridView1.CurrentRow.Cells[6].Value);
            frm.ShowDialog();
        }
        private void showLicenseDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicesnse showLicesnse = new frmShowLicesnse((int)dataGridView1.CurrentRow.Cells[1].Value,true);
            showLicesnse.ShowDialog();
        }
        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory((string)dataGridView1.CurrentRow.Cells[6].Value);
            frm.ShowDialog();
        }
        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicenseApplication frm = new frmDetainLicenseApplication();
            frm.ShowDialog();
        }
        private void btnRelease_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication();
            frm.ShowDialog();
        }

        private void relaseDetaiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReleaseDetainedLicenseApplication frm = new frmReleaseDetainedLicenseApplication((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
