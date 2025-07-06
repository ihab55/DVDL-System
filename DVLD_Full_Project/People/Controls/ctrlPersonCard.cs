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
using DVLD_Full_Project.Properties;
using static System.Net.Mime.MediaTypeNames;

namespace DVLD_Full_Project
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _PersonID = -1;
        private clsPerson _Person;
        public int PersonID
        {
            get { return _PersonID; }
        }
        public clsPerson SelectedPersonInfo
        {
            get { return _Person; }
        }
        public ctrlPersonCard()
        {
            InitializeComponent();
        }
        public void RestPersonInfo()
        {
            _Person = null;
            _PersonID = -1;
            clabName.Text = "[????]";
            clabID.Text = "[????]";
            clabNationalID.Text = "[????]";
            clabDate.Text = "[????]";
            clabAddress.Text = "[????]";
            clabPhone.Text = "[????]";
            clabEmail.Text = "[????]";
            clabCountry.Text = "[????]";
             clabGendor.Text = "Male";
             pbPerson.Image = Resources.person_boy;
            linkLabel1.Enabled = false;
        }
        private void _LoadImage()
        {
            if (System.IO.File.Exists(_Person.ImagePath))
            {
                pbPerson.ImageLocation =_Person.ImagePath;
                return;
            }else if (_Person.ImagePath == "")
            {
                pbPerson.Image = (_Person.Gendor == 0) ? Resources.person_boy : Resources.person_girl;
                return;
            }
                MessageBox.Show("Error loading image not founded", "Image Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        } 
        private void _FillPersonInfo()
        {
            _PersonID = _Person.PersonID;
            clabName.Text = _Person.FullName;
            clabID.Text = _Person.PersonID.ToString();
            clabNationalID.Text = _Person.NationalNo;
            clabDate.Text = _Person.DateOfBirth.ToShortDateString();
            clabAddress.Text = _Person.Address;
            clabPhone.Text = _Person.Phone;
            clabEmail.Text = _Person.Email;
            clabCountry.Text = clsCountry.Find(_Person.CountryInfo.ID).Name;
            clabGendor.Text = _Person.Gendor == 0 ? "Male" : "Female";
            _LoadImage();
            linkLabel1.Enabled = true;
        }
        public void LoadPersonInfo(int id)
        {
            _Person = clsPerson.Find(id);
            if (_Person == null)
            {
                RestPersonInfo();
                MessageBox.Show("User not founded", "not foumded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return ;
            }
            _FillPersonInfo();
        }
        public void LoadPersonInfo(string Nid)
        {
            _Person = clsPerson.Find(Nid);
            if (_Person == null)
            {
                RestPersonInfo();
                MessageBox.Show("User not founded", "not foumded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            _FillPersonInfo();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson(_PersonID);
            frm.ShowDialog();
            //Refreash
            LoadPersonInfo(_PersonID);
        }

        private void clabDate_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void clabCountry_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void labCountry_Click(object sender, EventArgs e)
        {

        }

        private void clabPhone_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void labPhone_Click(object sender, EventArgs e)
        {

        }

        private void labDateOfBirth_Click(object sender, EventArgs e)
        {

        }

        private void pbPerson_Click(object sender, EventArgs e)
        {

        }
    }
}
