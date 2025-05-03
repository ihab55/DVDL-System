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
        public ucFilterPerson()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                clsPerson person = null;
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                   
                        person = clsPerson.Find(int.Parse(textBox1.Text));
                        if (person != null)
                        {
                            ucPersonCard1.FillPersonCard(person.Id);
                        }
                        else
                        {
                            MessageBox.Show("Person not found");
                        }
                        break;
                    
                case 1:
                     person = clsPerson.Find(textBox1.Text);
                    if (person != null)
                    {
                        ucPersonCard1.FillPersonCard(person.Id);
                    }
                    else
                    {
                        MessageBox.Show("Person not found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    break;
                default:
                    return;
            }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
    }
}
