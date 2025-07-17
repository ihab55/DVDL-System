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
    public partial class ctrlApplicationBasicInfo : UserControl
    {
        private clsApplication _Application ;
        public int ApplicationID
        {
            get { return _Application.ApplicationID;}
        }
        public ctrlApplicationBasicInfo()
        {
            InitializeComponent();
        }
        public void ResetApplicationInfo() {
            _Application = null;

            txtID.Text = "[????]";
            txtStattus.Text = "[????]";
            txtType.Text = "[????]";
            txtFees.Text = "[????]";
            txtApplicant.Text = "[????]";
            txtDate.Text = "[????]";
            txtStatusDate.Text = "[????]";
            txtCreatedBy.Text = "[????]";
        }
        private void _FillApplicationInfo()
        {
            txtID.Text = _Application.ApplicationID.ToString();
            txtStattus.Text = _Application.ApplicationStatus.ToString();
            txtFees.Text = _Application.PaidFees.ToString();
            txtType.Text = _Application.AppTypeInfo.Title;
            txtApplicant.Text = _Application.PersonInfo.FullName;
            txtDate.Text = _Application.ApplicationDate.ToString("dd/MM/yyyy");
            txtStatusDate.Text = _Application.LastStatusDate.ToString("dd/MM/yyyy");
            txtCreatedBy.Text = _Application.CreatedbyInfo.UserName;
            txtApplicant.Tag = _Application.PersonInfo.PersonID;
        }
        public void LoadApplicationInfo(int ApplicationID)
        {
            _Application = clsApplication.FindBaseApplication(ApplicationID);
            if (_Application == null)
            {
                ResetApplicationInfo();
                MessageBox.Show("No Application with ApplicationID = " + ApplicationID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
                _FillApplicationInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmShowPersonInfo person = new frmShowPersonInfo(_Application.ApplicantPersonID);
            person.ShowDialog();

            LoadApplicationInfo(_Application.ApplicationID);// Refresh the application info after showing person details
        }
    }
}
