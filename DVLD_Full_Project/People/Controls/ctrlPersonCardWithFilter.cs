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
    public partial class ctrlPersonCardWithFilter : UserControl
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
        public int _PersonID { get { return ucPersonCard1.PersonID; } }
        private bool _EnableFilter = true;
        public bool EnableFilter
        {
            set
            {
                _EnableFilter = value;
                groupBox1.Enabled = _EnableFilter;
            }
            get { return _EnableFilter; }
        }
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }
        private void FindNow()
        {
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    ucPersonCard1.LoadPersonInfo(int.Parse(textBox1.Text));
                    break;
                case 1:
                    ucPersonCard1.LoadPersonInfo(textBox1.Text);
                    break;
            }
            if (OnPersonSelected != null && this.EnableFilter)
            {
                OnPersonSelected(ucPersonCard1.PersonID);
            }
        }
        private void btnSearchPerson_Click(object sender, EventArgs e)
        {
            FindNow();
        }
        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.DataBack += DataBackEvent;
            frm.ShowDialog();
        }
        private void DataBackEvent(object sender, int PersonID)
        {
            cbFilter.SelectedIndex = 0;
            textBox1.Text = PersonID.ToString();
            ucPersonCard1.LoadPersonInfo(PersonID);
        }
        public void LoadPersonInfo(int PersonID)
        {
            cbFilter.SelectedIndex = 0;
            textBox1.Text = PersonID.ToString();
            FindNow();
        }
        private void ucFilterPerson_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            textBox1.Focus();
        }
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                btnSearchPerson.PerformClick();
            }
            if (cbFilter.SelectedIndex == 0)
            {
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            }
        }
        public void FocusOnFilter()
        {
            textBox1.Focus();
        }
    }
}
