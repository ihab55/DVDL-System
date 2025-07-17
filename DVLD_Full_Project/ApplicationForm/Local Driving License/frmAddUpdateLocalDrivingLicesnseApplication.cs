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
    public partial class frmAddUpdateLocalDrivingLicesnseApplication : Form
    {
        public enum enMode { AddNew = 0, Update = 1 };

        private enMode _Mode;
        private int _LocalDrivingLicenseApplicationID = -1;
        private int _SelectedPersonID = -1;
        private clsLocalDrivingLicenseApplication _LocalDrivingLicenseApplication;
        public frmAddUpdateLocalDrivingLicesnseApplication()
        {
            InitializeComponent();
            _Mode = enMode.AddNew;
        }
        public frmAddUpdateLocalDrivingLicesnseApplication(int LocalDrivingLicenseApplicationID)
        {
            InitializeComponent();
            _Mode = enMode.Update;
            _LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplicationID;
        }
        private void _FillLicenseClassesInComoboBox()
        {
            DataTable dtLicenseClass = clsLicenseClass.GetAllLicenseClasses();
            foreach (DataRow dr in dtLicenseClass.Rows)
            {
                cbLicenseClass.Items.Add(dr["ClassName"]);
            }

        }
        private void _ResetDefualtValues()
        {
            _FillLicenseClassesInComoboBox();
            if (_Mode == enMode.AddNew)
            {
                ucFilterPerson1.FocusOnFilter();
                _LocalDrivingLicenseApplication = new clsLocalDrivingLicenseApplication();
                cbLicenseClass.SelectedIndex = 2;

                txtDate.Text = DateTime.Now.ToShortDateString();
                txtApplicationfees.Text = clsApplicationTypes.Find(1).Fees.ToString();//1 New Local Application
                txtCreatedby.Text = clsGlobal.CurrentUser.UserName;
            }
            else
            {
                labHead.Text = "Update Local Driving License Application";
                ucFilterPerson1.EnableFilter = false;
                btnSave.Enabled =btnNext.Enabled= tabPage2.Enabled = true;
                _LocalDrivingLicenseApplication = clsLocalDrivingLicenseApplication.FindByLocalDrivingAppLicenseID(_LocalDrivingLicenseApplicationID);
            }
        }
        private void _LoadData()
        {
            ucFilterPerson1.LoadPersonInfo(_LocalDrivingLicenseApplication.ApplicantPersonID);
            txtApplicationID.Text = _LocalDrivingLicenseApplication.ApplicationID.ToString();
            txtDate.Text = _LocalDrivingLicenseApplication.ApplicationDate.ToShortDateString();
            cbLicenseClass.SelectedIndex = cbLicenseClass.FindStringExact(_LocalDrivingLicenseApplication.licenseClassInfo.ClassName);
            txtApplicationfees.Text = _LocalDrivingLicenseApplication.PaidFees.ToString();
            txtCreatedby.Text = clsUser.FindByUserID(_LocalDrivingLicenseApplication.CreatedByUserID).UserName;
        }
        private void frmAddUpdateLocalDrivingLicesnseApplication_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();
            if (_Mode == enMode.Update)
            {
                _LoadData();
                _SelectedPersonID = _LocalDrivingLicenseApplication.ApplicantPersonID;
            }
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
            _SelectedPersonID = obj;
            btnNext.Enabled = tabPage2.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int LicenseClassID = cbLicenseClass.SelectedIndex+1;
            
            int ActiveApplicationID = clsApplication.GetActiveApplicationIDForLicenseClass(_SelectedPersonID
                ,clsApplication.enApplicationType.NewDrivingLicense, LicenseClassID);
            if (ActiveApplicationID != -99)
            {
                MessageBox.Show("Choose another License Class, the selected Person Already have an active application for the selected class with id=" + ActiveApplicationID, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbLicenseClass.Focus();
                return;
            }
            if (clsLicense.IsLicenseExistByPersonID(_SelectedPersonID,LicenseClassID))
            {
                MessageBox.Show("Person already have a license with the same applied driving class, Choose diffrent driving class", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _LocalDrivingLicenseApplication.ApplicantPersonID = ucFilterPerson1._PersonID;
            _LocalDrivingLicenseApplication.ApplicationDate = DateTime.Now;
            _LocalDrivingLicenseApplication.ApplicationTypeID = clsApplication.enApplicationType.NewDrivingLicense;
            _LocalDrivingLicenseApplication.ApplicationStatus = clsApplication.enApplicationStatus.New;
            _LocalDrivingLicenseApplication.LastStatusDate = DateTime.Now;
            _LocalDrivingLicenseApplication.PaidFees = Convert.ToSingle(txtApplicationfees.Text);
            _LocalDrivingLicenseApplication.CreatedByUserID = clsGlobal.CurrentUser.UserID;
            _LocalDrivingLicenseApplication.LicenseClassID = LicenseClassID;
            if (_LocalDrivingLicenseApplication.Save())
            {
                txtApplicationID.Text = _LocalDrivingLicenseApplication.LocalDrivingLicenseApplicationID.ToString();

                _Mode = enMode.Update;
                labHead.Text = "Update Local Driving License Application";
                MessageBox.Show("Application Added Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Application Not Added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       
    }
}
