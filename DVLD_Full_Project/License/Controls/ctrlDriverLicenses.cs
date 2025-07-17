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

namespace DVLD_Full_Project.License.Controls
{
    public partial class ctrlDriverLicenses : UserControl
    {
        private clsDriver _Driver;
        private DataTable _dtDriverLocalLicensesHistory;
        private DataTable _dtDriverInternationalLicensesHistory;

        public ctrlDriverLicenses()
        {
            InitializeComponent();
        }
        private void _LoadLocalLicenseInfo()
        {
            _dtDriverLocalLicensesHistory = _Driver.GetLocalDriverLicenses();

            dgLocalLicense.DataSource = _dtDriverLocalLicensesHistory;
            lbCountLocal.Text = _dtDriverLocalLicensesHistory.Rows.Count.ToString();

            dgLocalLicense.Columns[0].HeaderText = "Lic.ID";
            dgLocalLicense.Columns[0].Width = 50;

            dgLocalLicense.Columns[1].HeaderText = "App.ID";
            dgLocalLicense.Columns[1].Width = 50;

            dgLocalLicense.Columns[2].HeaderText = "Class Name";
            dgLocalLicense.Columns[2].Width = 160;

            dgLocalLicense.Columns[3].HeaderText = "Issue Date";
            dgLocalLicense.Columns[3].Width = 130;

            dgLocalLicense.Columns[4].HeaderText = "Expiration Date";
            dgLocalLicense.Columns[4].Width = 130;

            dgLocalLicense.Columns[5].HeaderText = "Is Active";
            dgLocalLicense.Columns[5].Width = 70;
        }
        private void _LoadInternationalLicenseInfo()
        {
            _dtDriverInternationalLicensesHistory = clsInternationalLicense.GetDriverInternationalLicenses(_Driver.DriverID);
            dgInternationalLicense.DataSource = _dtDriverInternationalLicensesHistory;
            lbCountInt.Text = _dtDriverInternationalLicensesHistory.Rows.Count.ToString();

            dgInternationalLicense.Columns[0].HeaderText = "Int.License ID";
            dgInternationalLicense.Columns[0].Width = 80;

            dgInternationalLicense.Columns[1].HeaderText = "Application ID";
            dgInternationalLicense.Columns[1].Width = 80;

            dgInternationalLicense.Columns[2].HeaderText = "L.License ID";
            dgInternationalLicense.Columns[2].Width = 80;

            dgInternationalLicense.Columns[3].HeaderText = "Issue Date";
            dgInternationalLicense.Columns[3].Width = 130;

            dgInternationalLicense.Columns[4].HeaderText = "Expiration Date";
            dgInternationalLicense.Columns[4].Width = 130;

            dgInternationalLicense.Columns[5].HeaderText = "Is Active";
            dgInternationalLicense.Columns[5].Width = 60;
        }
        public void LoadInfoByPersonID(int PersonID)
        {
            _Driver = clsDriver.FindByPersonID(PersonID);
            if (_Driver == null)
            {
                MessageBox.Show($"No driver found with the provided Person ID = {PersonID}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _LoadLocalLicenseInfo();
            _LoadInternationalLicenseInfo();
        }

        private void InternationalLicenseHistorytoolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInternationalLicenseInfo frm = new frmInternationalLicenseInfo
                ((int)dgInternationalLicense.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }

        private void showLicenseInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowLicenseInfo frm = new frmShowLicenseInfo
                ((int)dgLocalLicense.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
    }
}
