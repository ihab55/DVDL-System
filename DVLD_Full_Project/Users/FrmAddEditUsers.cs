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

namespace DVLD_Full_Project.Use_Controller
{
    public partial class frmAddEditUsers : Form
    {
        private enum _enFormMode
        {
            _enAddUsers = 0,
            _enEditUsers = 1
        }
        private _enFormMode _Mode ;
        private int _UserID = -99;
        private clsUser _User;
        public frmAddEditUsers()
        {
            InitializeComponent();
            _Mode = _enFormMode._enAddUsers;
        }
        public frmAddEditUsers(int UserID)
        {
            InitializeComponent();
            _Mode = _enFormMode._enEditUsers;
            this._UserID = UserID;
        }

        private void FrmAddEditUsers_Load(object sender, EventArgs e)
        {
            if (_Mode == _enFormMode._enAddUsers)
            {
                tabControl1.TabPages[1].Enabled = false;
            }
            else
            {
                _User = clsUser.FindByUserID(_UserID);
                labHead.Text = "Edit User";
                ucFilterPerson1.EnableFilter = false;
                ucFilterPerson1.LoadPersonInfo(_User.PersonID);
                txtUsername.Text = _User.UserName;
                txtPassword.Text = _User.Password;
                txtCopyPassword.Text = _User.Password;
                chbIsActive.Checked = _User.IsActive;
                txtUserID.Text = _User.UserID.ToString();
            }
        }
        private bool _ChekUserValidity()
        {
            bool isValid = true;
            errorProvider1.Clear();
            if (txtUsername.Text =="")
            {
                isValid = false;
                errorProvider1.SetError(txtUsername, "Please Enter User Name");
            }
            if (txtPassword.Text == "")
            {
                isValid = false;
                errorProvider1.SetError(txtPassword, "Please Enter Password");
            }
            if (txtCopyPassword.Text == "")
            {
                isValid = false;
                errorProvider1.SetError(txtCopyPassword, "Please Enter Confirm Password");
            }
            return isValid;
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
            _User = new clsUser();
            _User.PersonID = obj;
            _User.PersonInfo = clsPerson.Find(obj);
            tabPage2.Enabled = true;
        }
        private bool _ValidatePassword()
        {
            if (txtPassword.Text.Trim() != txtCopyPassword.Text.Trim())
            {
                errorProvider1.SetError(txtCopyPassword, "Password not match");
                return false;
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (_ChekUserValidity() && _ValidatePassword())
            {
                _User.UserName = txtUsername.Text.Trim();
                _User.Password = txtPassword.Text.Trim();
                _User.IsActive  = chbIsActive.Checked;
                if (_User.Save())
                {
                    _Mode = _enFormMode._enEditUsers;
                    _UserID = _User.UserID;
                    txtUserID.Text = _UserID.ToString();
                    MessageBox.Show("User data saved successfully.", "Done :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else 
                { 
                   MessageBox.Show("User is already exsits.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Enter your Data\\Password not right","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
