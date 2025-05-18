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
    public partial class frmNewLocalDrivingLicenseAPP : Form
    {
        private clsLocalDrivingLicenseApp _LDL = new clsLocalDrivingLicenseApp();
        public frmNewLocalDrivingLicenseAPP()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            tabControl1.SelectedTab = tabPage2;
        }

        private void ucFilterPerson1_OnPersonSelected(int obj)
        {
            _LDL.personID = obj;
            tabPage2.Enabled = true;
            btnNext.Enabled = true;
            txtApplicationfees.Text = _LDL.Fees.ToString();
            txtCreatedby.Text = clsCurrentUsersInfo.CurrentUser.UserName;
            txtDate.Text = DateTime.Now.ToString("yyyy/MM/dd");
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _LDL.ClassID = comboBox1.SelectedIndex+1;
            if (_LDL.IsExists())
            {
                MessageBox.Show("This Application Already Exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (_LDL.AddNewLocalDrivingLicenseApp(clsCurrentUsersInfo.CurrentUser.Id))
            {
                btnSave.Enabled = false;
                txtApplicationID.Text = _LDL.LocalDrivingLicenseApplicationID.ToString();
                MessageBox.Show("Application Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Application Not Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
