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
    public partial class frmmLogin : Form
    {
        private string filePath = "D:\\Courses\\NewProjects\\FullProject\\DVLD_Full_Project\\UserLogin.txt";
        public frmmLogin()
        {
            InitializeComponent();
        }
        private string[] _SplitSpecialString(string input)
        {
            return input.Split(new string[] { "#//#" }, StringSplitOptions.None);
        }
        private string _CreateDataString(string username, string password, bool isActive)
        {
            return $"{username}#//#{password}#//#{isActive}";
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
            bool IsActive = false;
            if (clsUser.IsUserRight(txtUsername.Text,txtPassword.Text,ref IsActive))
            {
                if (IsActive)
                {
                    this.DialogResult = DialogResult.OK;
                    errorProvider1.Clear();
                    File.WriteAllText(filePath,checkBox1.Checked? _CreateDataString(txtUsername.Text, txtPassword.Text, checkBox1.Checked): string.Empty);
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

        private void frmmLogin_Load(object sender, EventArgs e)
        {
            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                string []Data =_SplitSpecialString(File.ReadAllText(filePath));
                txtUsername.Text = Data[0];
                txtPassword.Text = Data[1];
                checkBox1.Checked = bool.Parse(Data[2]);
            }
        }
    }
}
