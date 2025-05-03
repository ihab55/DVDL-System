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
    public partial class frmmLogin : Form
    {
        static private clsUser _User;
        static private bool IsRememberMe = false;
        public frmmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtPassword.PasswordChar = (txtPassword.PasswordChar == '\0') ? '*' : '\0';
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (clsUser.IsUserRight(txtUsername.Text,txtPassword.Text))
            {
                _User = clsUser.Find(txtUsername.Text);
                if (_User.IsActive)
                {
                    this.DialogResult = DialogResult.OK;
                    errorProvider1.Clear();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ask Admin to Active Account", "Informatio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    errorProvider1.SetError(txtUsername, "User is not active");
                    txtUsername.Focus();
                }
            }
            else
            {
                MessageBox.Show("Invalid UserName or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                errorProvider1.SetError(txtUsername, "Invalid UserName or Password");
                txtUsername.Focus();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            IsRememberMe = checkBox1.Checked;
        }

        private void frmmLogin_Load(object sender, EventArgs e)
        {
            if (IsRememberMe)
            {
                txtUsername.Text = _User.UserName;
                txtPassword.Text = _User.Password;
                checkBox1.Checked = true;
            }
        }
    }
}
