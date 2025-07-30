using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;

namespace DVLD_Full_Project
{
    public partial class frmLogin : Form
    {
        public frmLogin()
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
            clsGlobal.CurrentUser = clsUser.FindByUserNameAndPassword(txtUsername.Text.Trim(), txtPassword.Text.Trim());
            if (clsGlobal.CurrentUser == null)
            {
                MessageBox.Show("Invalid UserName or Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (checkBox1.Checked)
            {
                clsGlobal.SaveRememberMeCredentials(txtUsername.Text.Trim(),txtPassword.Text.Trim());
            }
            if (clsGlobal.CurrentUser.IsActive)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }
                MessageBox.Show("Ask Admin to Active Account", "Informatio", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtUsername.Focus();
        }

        private void frmmLogin_Load(object sender, EventArgs e)
        {
            string UserName = "" , Password = "" ;
            if (clsGlobal.GetStoredCredential(ref UserName, ref Password))
            {
                txtUsername.Text = UserName;
                txtPassword.Text = Password;
                checkBox1.Checked = true;
            }
        }
    }
}
