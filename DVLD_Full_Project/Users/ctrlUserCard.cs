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
    public partial class ctrlUserCard : UserControl
    {
        private clsUser _User;
        public int UserID
        {
            get { return _User.UserID; }
        }

        public ctrlUserCard()
        {
            InitializeComponent();
        }
        public void LoadUserInfo(int UserID)
        {
            _User = clsUser.FindByUserID(UserID);
            if (_User != null)
            {
                _FillUserInfo();
            }
            else
            {
                MessageBox.Show("User not found", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void _FillUserInfo()
        {
            ucPersonCard1.LoadPersonInfo(_User.PersonID);
            clabUserID.Text = _User.UserID.ToString();
            clabUserName.Text = _User.UserName;
            clabIsActive.Text = _User.IsActive ? "Yes" : "No";
        }
    }
}
