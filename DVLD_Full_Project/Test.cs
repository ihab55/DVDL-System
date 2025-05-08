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
using DVLD_Full_Project.Use_Controller;

namespace DVLD_Full_Project
{
    public partial class Test : Form
    {
        public Test()
        {
            InitializeComponent();
        }

        private void ucFilterPerson2_OnPersonSelected(int obj)
        {
            MessageBox.Show(obj.ToString());
        }
    }
}
