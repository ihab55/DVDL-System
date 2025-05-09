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
    public partial class FrmAddEditUsers : Form
    {
        private enum _enFormMode
        {
            _enAddUsers = 0,
            _enEditUsers = 1
        }
        private _enFormMode _Mode = 0;
        private clsUser _User;
        public FrmAddEditUsers()
        {
            InitializeComponent();
            _Mode = _enFormMode._enAddUsers;
            _User = new clsUser();
        }
        public FrmAddEditUsers(int id)
        {
            InitializeComponent();
            _Mode = _enFormMode._enEditUsers;
            _User = clsUser.Find(id);
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
            _User.PersonID = obj;
            tabPage2.Enabled = true;
        }
        private bool _ValidatePassword()
        {
            if (txtPassword.Text != txtCopyPassword.Text)
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
                
                _User.UserName = txtUsername.Text;
                _User.Password = txtPassword.Text;
                _User.IsActive  = chbIsActive.Checked;
                if (_User.Save())
                {
                    txtUserID.Text = _User.Id.ToString();
                    MessageBox.Show("User data saved successfully.", "Done :)", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
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
        private void FrmAddEditUsers_Load(object sender, EventArgs e)
        {
            if (_Mode == _enFormMode._enAddUsers)
            {
                tabControl1.TabPages[1].Enabled = false;
            }
            else
            {
                labHead.Text = "Edit User";
                labHead.Left = 230;
                ucFilterPerson1.Enabled = false;
                ucFilterPerson1.FillPersonCard(_User.PersonID);
                txtUsername.Text = _User.UserName;
                txtPassword.Text = _User.Password;
                txtCopyPassword.Text = _User.Password;
                chbIsActive.Checked = _User.IsActive;
                txtUserID.Text = _User.Id.ToString();
            }
        }
    }
}
