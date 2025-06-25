using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
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
            _Refresh();
        }

        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLocalApp localApp = new frmShowLocalApp((int)dataGridView1.CurrentRow.Cells[0].Value);
            localApp.ShowDialog();
        }

        private void eDitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implemnt Yet", "Info", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() != "Completed")
            {
                clsLocalDrivingLicenseApp.DeleteLocalApp((int)dataGridView1.CurrentRow.Cells[0].Value);
                if (MessageBox.Show("Do you want Delete this app","Check",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes) {
                    MessageBox.Show("Application Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    return;
                }
            }
            else
            {
                MessageBox.Show("You Can't Delete Completed Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _Refresh();
        }

        private void issueDrivingLicToolStripMenuItem_Click(object sender, EventArgs e)
        {
        frmIssueDrivingLicense frm = new frmIssueDrivingLicense((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Refresh();
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicesnse frm = new frmShowLicesnse((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLicenseHistory frm = new frmLicenseHistory(dataGridView1.CurrentRow.Cells[2].Value.ToString());
            frm.ShowDialog();
        }

        private void canelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LocalID = (int)dataGridView1.CurrentRow.Cells[0].Value;
            if (clsLocalDrivingLicenseApp.GetAppByID(LocalID).CancelLocalAppStatus())
            {
                MessageBox.Show($"Application {LocalID} Canceled Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _Refresh();
            }
            else
            {
                MessageBox.Show($"Application {LocalID} Is Aleady Canceled OR Completed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointment frm = new frmTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value,1);
            frm.ShowDialog();
            _Refresh();
        }
        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointment frm = new frmTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value, 2);
            frm.ShowDialog();
            _Refresh();
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmTestAppointment frm = new frmTestAppointment((int)dataGridView1.CurrentRow.Cells[0].Value, 3);
            frm.ShowDialog();
            _Refresh();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            contextMenuStrip1.Enabled = true;
            if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "New")
            {
                cmsShowLicense.Enabled = false;
                cmsSechduleTest.Enabled = cmsDeleteApp.Enabled = cmsCancelApp.Enabled = cmsEditApp.Enabled = true;
                switch ((int)dataGridView1.CurrentRow.Cells[5].Value)
                {
                    case (0):
                        cmsStrretTest.Enabled = false;
                        cmsWrittenTest.Enabled = false;
                        cmsVisionTest.Enabled = true;
                        break;
                    case (1):
                        cmsWrittenTest.Enabled = true;
                        cmsVisionTest.Enabled = false;
                        cmsStrretTest.Enabled = false;
                        break;
                    case (2):
                        cmsStrretTest.Enabled = true;
                        cmsWrittenTest.Enabled = false;
                        cmsVisionTest.Enabled = false;
                        break;
                    default:
                        cmsSechduleTest.Enabled = false;
                        cmsIssueDrivingLic.Enabled = true; break;
                }
            }
            else if (dataGridView1.CurrentRow.Cells[6].Value.ToString() == "Canceled")
            {
                cmsEditApp.Enabled = cmsCancelApp.Enabled = cmsIssueDrivingLic.Enabled = cmsSechduleTest.Enabled = false;
                cmsShowPersonLicense.Enabled = cmsShowLicense.Enabled = cmsShowApp.Enabled = false;
                cmsDeleteApp.Enabled = true;
            }
            else
            {
                cmsEditApp.Enabled=cmsDeleteApp.Enabled=cmsCancelApp.Enabled=cmsIssueDrivingLic.Enabled=cmsSechduleTest.Enabled=false;
                cmsShowPersonLicense.Enabled=cmsShowLicense.Enabled=cmsShowApp.Enabled=true;
            }
        }
    }
}
