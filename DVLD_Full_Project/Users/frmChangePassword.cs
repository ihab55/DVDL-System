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

namespace DVLD_Full_Project.UsersForm
{
    public partial class frmChangePassword : Form
    {
        private clsUser _clsUser;
        public frmChangePassword(int UserID)
        {
            InitializeComponent();
            _clsUser = clsUser.FindByUserID(UserID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool txtCurrentPassWord_Right()
        {
            if (txtCurrPassword.Text.Trim() != clsGlobal.CurrentUser.Password)
            {
                errorProvider1.SetError(txtCurrPassword, "Wrong Password");
                return false;
            }
                errorProvider1.SetError(txtCurrPassword, string.Empty); // Clear error
                return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren() || !txtCurrentPassWord_Right())
            {
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro",
                    "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _clsUser.Password = txtNewPass.Text.Trim();
            if (_clsUser.Save())
            {
                MessageBox.Show("Password Changed Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Error in changing password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ucUserCard1.LoadUserInfo(_clsUser.UserID);
        }

        private void txtEmpty_Validating(object sender, CancelEventArgs e)
        {
            TextBox txt = sender as TextBox;
            if (txt.Text.Trim() == "")
            {
                errorProvider1.SetError(txt, "Enter A value");
                e.Cancel = true; // Prevent focus loss
            }
            else
            {
                errorProvider1.SetError(txt, string.Empty); // Clear error
            }
        }

        private void txtConfpass_Validating(object sender, CancelEventArgs e)
        {
            txtEmpty_Validating(sender, e);
            if (txtConfpass.Text != txtNewPass.Text)
            {
                errorProvider1.SetError(txtConfpass, "Password does not match");
                e.Cancel = true; // Prevent focus loss
            }
            else
            {
                errorProvider1.SetError(txtConfpass, string.Empty); // Clear error
            }
        }
    }
}
