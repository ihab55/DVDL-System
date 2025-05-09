using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project.UsersForm
{
    public partial class frmUsersCard : Form
    {
        public frmUsersCard(int ID)
        {
            InitializeComponent();
            ucUserCard1.FillUserCard(ID);
        }
        public frmUsersCard(string username)
        {
            InitializeComponent();
            ucUserCard1.FillUserCard(username);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
