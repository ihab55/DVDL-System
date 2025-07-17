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
    public partial class frmListLocalDrivingLicesnseApplications : Form
    {
        private DataTable _dtAllLocalDrivingLicenseApplications;
        public frmListLocalDrivingLicesnseApplications()
        {
            InitializeComponent();
        }
        private void frmListLocalDrivingLicesnseApplications_Load(object sender, EventArgs e)
        {
            _dtAllLocalDrivingLicenseApplications = clsLocalDrivingLicenseApplication.GetAllLocalDrivingLicenseApplications();
            dataGridView1.DataSource = _dtAllLocalDrivingLicenseApplications;

            labNum.Text = dataGridView1.Rows.Count.ToString();

            dataGridView1.Columns[0].HeaderCell.Value = "L.D.L.AppID";
            dataGridView1.Columns[0].Width = 100;

            dataGridView1.Columns[1].HeaderCell.Value = "Driving Class";
            dataGridView1.Columns[1].Width = 200;

            dataGridView1.Columns[2].HeaderCell.Value = "National No.";
            dataGridView1.Columns[2].Width = 100;

            dataGridView1.Columns[3].HeaderCell.Value = "Full Name";
            dataGridView1.Columns[3].Width = 225;

            dataGridView1.Columns[4].HeaderCell.Value = "Application Date";
            dataGridView1.Columns[4].Width = 125;

            dataGridView1.Columns[5].HeaderCell.Value = "Passed Tests";
            dataGridView1.Columns[5].Width = 125;

            cmbFilter.SelectedItem = 0;
        }
        private void showApplicationDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicenseApplicationInfo localApp = new frmLocalDrivingLicenseApplicationInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            localApp.ShowDialog();
            // Refresh the data grid view after closing the form
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Visible = (cmbFilter.SelectedIndex != 0);
            if (textBox1.Visible)
            {
                textBox1.Text = string.Empty;
                textBox1.Focus();
            }
            _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
            labNum.Text = _dtAllLocalDrivingLicenseApplications.Rows.Count.ToString();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = "";
            //Map Selected Filter to real Column name 
            switch (cmbFilter.Text)
            {

                case "L.D.L.AppID":
                    FilterColumn = "LocalDrivingLicenseApplicationID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;


                case "Full Name":
                    FilterColumn = "FullName";
                    break;

                case "Status":
                    FilterColumn = "Status";
                    break;
                default:
                    FilterColumn = "None";
                    break;

            }
            if (string.IsNullOrEmpty(textBox1.Text.Trim()) || cmbFilter.Text == "None")
            {
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = "";
                labNum.Text = dataGridView1.Rows.Count.ToString();
                return;
            }
            if (FilterColumn == "LocalDrivingLicenseApplicationID")
                //in this case we deal with integer not string.
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                _dtAllLocalDrivingLicenseApplications.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            labNum.Text = dataGridView1.Rows.Count.ToString();
        }
        private void eDitApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
           frmAddUpdateLocalDrivingLicesnseApplication frm = new frmAddUpdateLocalDrivingLicesnseApplication((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //we allow number incase L.D.L.AppID id is selected.
            if (cmbFilter.Text == "L.D.L.AppID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdateLocalDrivingLicesnseApplication frm = new frmAddUpdateLocalDrivingLicesnseApplication();
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }
        private void deleteApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //if (dataGridView1.CurrentRow.Cells[6].Value.ToString() != "Completed")
            //{
            //    clsLocalDrivingLicenseApplication.((int)dataGridView1.CurrentRow.Cells[0].Value);
            //    if (MessageBox.Show("Do you want Delete this app","Check",MessageBoxButtons.YesNo,MessageBoxIcon.Question,MessageBoxDefaultButton.Button2)==DialogResult.Yes) {
            //        MessageBox.Show("Application Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        return;
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("You Can't Delete Completed Application", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
            //_Refresh();
        }
        private void issueDrivingLicToolStripMenuItem_Click(object sender, EventArgs e)
        {
        frmIssueDrivingLicense frm = new frmIssueDrivingLicense((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void showLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int LicenseID = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID
                ((int)dataGridView1.CurrentRow.Cells[0].Value).GetActiveLicenseID();
            if (LicenseID == -99){
                MessageBox.Show("This application does not have an active license.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmShowLicenseInfo frm = new frmShowLicenseInfo(LicenseID);
            frm.ShowDialog();
        }

        private void showPersonLicenseHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = clsPerson.Find(dataGridView1.CurrentRow.Cells[2].Value.ToString()).PersonID;
            if (!clsDriver.IsExistsByPersonID(PersonID) )
            {
                MessageBox.Show("This person does not have a driving license history.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            frmShowPersonLicenseHistory frm = new frmShowPersonLicenseHistory(PersonID);
            frm.ShowDialog();
        }

        private void canelApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure do want to cancel this application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            clsLocalDrivingLicenseApplication LocalDrivingLicenseApplication =
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((int)dataGridView1.CurrentRow.Cells[0].Value);
            if (LocalDrivingLicenseApplication != null)
            {
                if (LocalDrivingLicenseApplication.Cancel())
                {
                    MessageBox.Show("Application Cancelled Successfully.", "Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //refresh the form again.
                    frmListLocalDrivingLicesnseApplications_Load(null, null);
                }
                else
                {
                    MessageBox.Show("Failed to cancel the application.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }

        private void scheduleVisionTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointments frm = new frmListTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value,clsTestType.enTestType.VisionTest);
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }
        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointments frm = new frmListTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestType.enTestType.WrittenTest);
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void scheduleStreetTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmListTestAppointments frm = new frmListTestAppointments((int)dataGridView1.CurrentRow.Cells[0].Value, clsTestType.enTestType.StreetTest);
            frm.ShowDialog();
            frmListLocalDrivingLicesnseApplications_Load(null, null);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            clsLocalDrivingLicenseApplication localDrivingLicenseApplication = 
                clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID((int)dataGridView1.CurrentRow.Cells[0].Value);
            byte TestPassed = localDrivingLicenseApplication.GetPassedTestCount();
            bool IsLicenseIssued = localDrivingLicenseApplication.IsLicenseIssued();

            cmsEditApp.Enabled = (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            cmsCancelApp.Enabled = cmsDeleteApp.Enabled = cmsEditApp.Enabled;
            cmsSechduleTest.Enabled = !IsLicenseIssued && (localDrivingLicenseApplication.ApplicationStatus == clsApplication.enApplicationStatus.New);
            if (cmsSechduleTest.Enabled)
            {
                bool PassedVisionTest = localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.VisionTest); ;
                bool PassedWrittenTest = localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.WrittenTest);
                bool PassedStreetTest = localDrivingLicenseApplication.DoesPassTestType(clsTestType.enTestType.StreetTest);
                cmsVisionTest.Enabled = !PassedVisionTest;
                cmsWrittenTest.Enabled = !PassedWrittenTest && PassedVisionTest;
                cmsStrretTest.Enabled = !PassedStreetTest && PassedWrittenTest && PassedVisionTest;
            }
            cmsIssueDrivingLic.Enabled = (TestPassed == 3) && !IsLicenseIssued;
            cmsShowLicense.Enabled = IsLicenseIssued;

        }
    }
}
