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
    public partial class ucFilterPerson : UserControl
    {
        public event Action<int> OnPersonSelected;
        protected virtual void PersonSelected(int Personid)
        {
            Action<int> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(Personid);
            }
        }

        public ucFilterPerson()
        {
            InitializeComponent();
        }
        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            bool Isfouned = false;
            try
            {
                switch (cbFilter.SelectedIndex)
                {
                    case 0:
                        Isfouned = ucPersonCard1.FillPersonCard(int.Parse(textBox1.Text));
                        break;
                    case 1:
                        Isfouned = ucPersonCard1.FillPersonCard(textBox1.Text);
                        break;
                    default:
                        MessageBox.Show("Error in comboBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                }
                if (OnPersonSelected != null && Isfouned)//&& filterEnable
                {
                    OnPersonSelected(ucPersonCard1.ID);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrEditPerson frm = new frmAddOrEditPerson();
            frm.ShowDialog();
        }
        public void FillPersonCard(int ID)
        {
            ucPersonCard1.FillPersonCard(ID);
        }
    }
}
