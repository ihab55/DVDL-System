using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project
{
    public partial class frmShowPersonInfo : Form
    {
        public frmShowPersonInfo(int ID)
        {
            InitializeComponent();
            ucPersonCard1.LoadPersonInfo(ID);
        }
        public frmShowPersonInfo(string NatID)
        {
            InitializeComponent();
            ucPersonCard1.LoadPersonInfo(NatID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
