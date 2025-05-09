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
    public partial class ucUserCard : UserControl
    {
        
        public ucUserCard()
        {
            InitializeComponent();
        }
        public void FillUserCard(int userID)
        {
            clsUser _user = clsUser.Find(userID);
            if (_user != null)
            {
                ucPersonCard1.FillPersonCard(_user.PersonID);
                clabUserID.Text = _user.Id.ToString();
                clabUserName.Text = _user.UserName;
                clabIsActive.Text = _user.IsActive ? "Yes" : "No";
            }
            else
            {
                MessageBox.Show("User not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        public void FillUserCard(string username)
        {
            clsUser _user = clsUser.Find(username);
            if (_user != null)
            {
                ucPersonCard1.FillPersonCard(_user.PersonID);
                clabUserID.Text = _user.Id.ToString();
                clabUserName.Text = _user.UserName;
                clabIsActive.Text = _user.IsActive ? "Yes" : "No";
            }
            else
            {
                MessageBox.Show("User not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
