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

namespace DVLD_Full_Project
{
    public partial class frmAddOrEditPerson : Form
    {
        private enum _enFormMode
        {
            _enAddPeople = 0,
            _enEditPerson = 1
        }
        private _enFormMode _Mode;
        private int _ID;
        private clsPerson _Person;
        public frmAddOrEditPerson(int ID)
        {
            InitializeComponent();
            _ID = ID;
            _Mode = (ID==-1) ? _enFormMode._enAddPeople : _Mode = _enFormMode._enEditPerson;
        }
        void _RefrashPersonCard()
        {

            if (_Mode == _enFormMode._enAddPeople)
            {
                _Person = new clsPerson();
                return;
            }
            _Person = clsPerson.Find(_ID);
            if (_Person == null)
            {
                MessageBox.Show("Person Not Found", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            label1.Text = "Edit Person";
            ucAddEditPerson1.FillCardForEdit(_Person);
        }
        private void frmAddOrEdit_Load(object sender, EventArgs e)
        {
            _RefrashPersonCard();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ucAddEditPerson1.GetData(ref _Person))
            {
                if (_Person.Save())
                {
                    MessageBox.Show("Person Save Succes :)", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    switch (_Mode)
                    {
                        case _enFormMode._enAddPeople:
                            _Mode = _enFormMode._enEditPerson;
                            _ID = _Person.Id;
                            _RefrashPersonCard();
                            break;
                        case _enFormMode._enEditPerson:
                            this.Close();
                            break;
                    }

                }
            }
            else
            {
                MessageBox.Show("Somthing Went Error","Erroe",MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
