using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project
{
    public partial class frmCardDetailsPerson : Form
    {
        private int _ID;
        public frmCardDetailsPerson(int ID)
        {
            InitializeComponent();
            _ID = ID;
        }

        private void frmCardDetailsPerson_Load(object sender, EventArgs e)
        {
            ucPersonCard1.FillPersonCard(_ID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddOrEdit frm = new frmAddOrEdit(_ID);
            frm.ShowDialog();
            ucPersonCard1.FillPersonCard(_ID);
        }
    }
}
