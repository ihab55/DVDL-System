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
    public partial class frmCardDetailsPerson : Form
    {
        public frmCardDetailsPerson(int ID)
        {
            InitializeComponent();
            ucPersonCard1.FillPersonCard(ID);
        }
        public frmCardDetailsPerson(string NatID)
        {
            InitializeComponent();
            ucPersonCard1.FillPersonCard(NatID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
