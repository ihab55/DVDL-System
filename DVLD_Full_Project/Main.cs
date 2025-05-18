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
using DVLD_Full_Project.UsersForm;

namespace DVLD_Full_Project
{
    public partial class Main : Form
    {
        public Main(string username)
        {
            InitializeComponent();
            clsCurrentUsersInfo.CurrentUser =clsUser.Find(username);
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeople frm = new frmPeople();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implamtion yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsers frm = new frmUsers();
            frm.ShowDialog();
        }
        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.IsRestart = true;
        }

        private void currentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUsersCard frm = new frmUsersCard(clsCurrentUsersInfo.CurrentUser.UserName);
            frm.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserChangePass frm = new frmUserChangePass(clsCurrentUsersInfo.CurrentUser.UserName);
            frm.ShowDialog();
        }

        private void drivingLicensesServuceToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageApplicationTypes frm = new frmManageApplicationTypes();
            frm.ShowDialog();
        }

        private void manageTestTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmManageTest frm = new frmManageTest();
            frm.ShowDialog();
        }

        private void localDrivingLicenseApplicationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLocalDrivingLicense frm = new frmLocalDrivingLicense();
            frm.ShowDialog();
        }

        private void localLicenseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmNewLocalDrivingLicenseAPP frm = new frmNewLocalDrivingLicenseAPP();
            frm.ShowDialog();
        }
    }
}
