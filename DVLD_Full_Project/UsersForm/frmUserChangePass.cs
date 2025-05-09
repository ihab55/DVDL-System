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
    public partial class frmUserChangePass : Form
    {
        private clsUser _clsUser;
        public frmUserChangePass(int id)
        {
            InitializeComponent();
            _clsUser = clsUser.Find(id);
            ucUserCard1.FillUserCard(_clsUser.Id);
        }
        public frmUserChangePass(string username)
        {
            InitializeComponent();
            _clsUser = clsUser.Find(username);
            ucUserCard1.FillUserCard(_clsUser.Id);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            errorProvider1.Clear();
            if (txtCurrPassword.Text == _clsUser.Password)
            {
                if (txtNewPass.Text == txtConfpass.Text)
                {
                    _clsUser.Password = txtNewPass.Text;
                    if (_clsUser.Save())
                    {
                        MessageBox.Show("Password changed successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Error changing password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    errorProvider1.SetError(txtConfpass, "Password does not match");
                }
            }
            else
            {
                errorProvider1.SetError(txtCurrPassword, "Current password is incorrect");
            }
        }
    }
}
