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
    public partial class ucPersonCard : UserControl
    {
        public int ID
        {
            get { return int.Parse(clabID.Text); }
        }
        public ucPersonCard()
        {
            InitializeComponent();
        }
        public bool FillPersonCard(int id)
        {
            clsPerson person = clsPerson.Find(id);
            if (person != null)
            {
                clabName.Text = person.FullName();
                clabID.Text = person.Id.ToString();
                clabNationalID.Text = person.NationalID;
                clabDate.Text = person.DateOfBirth.ToShortDateString();
                clabAddress.Text = person.Address;
                clabPhone.Text = person.Phone;
                clabEmail.Text = person.Email;
                clabCountry.Text = clsCountry.Find(person.CountryId).CountryName;
                switch (person.Gendor)
                {
                    case 0:
                        clabGendor.Text = "Male";
                        pictureBox10.Image = Resources.person_boy;
                        break;
                    case 1:
                        clabGendor.Text = "Female";
                        pictureBox10.Image = Resources.person_girl;
                        break;
                }
                if (person.ImagePath != "")
                {
                    pictureBox10.Image = System.Drawing.Image.FromFile(person.ImagePath);
                }
                return true;
            }           
                MessageBox.Show("User not founded","not foumded",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return false;
            }
        public bool FillPersonCard(string Nid)
        {
            clsPerson person = clsPerson.Find(Nid);
            if (person != null)
            {
                clabName.Text = person.FullName();
                clabID.Text = person.Id.ToString();
                clabNationalID.Text = person.NationalID;
                clabDate.Text = person.DateOfBirth.ToShortDateString();
                clabAddress.Text = person.Address;
                clabPhone.Text = person.Phone;
                clabEmail.Text = person.Email;
                clabCountry.Text = clsCountry.Find(person.CountryId).CountryName;
                switch (person.Gendor)
                {
                    case 0:
                        clabGendor.Text = "Male";
                        pictureBox10.Image = Resources.person_boy;
                        break;
                    case 1:
                        clabGendor.Text = "Female";
                        pictureBox10.Image = Resources.person_girl;
                        break;
                }
                if (person.ImagePath != "")
                {
                    pictureBox10.Image = System.Drawing.Image.FromFile(person.ImagePath);
                }
                return true;
            }
                MessageBox.Show("User not founded", "not foumded", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
        }
    }
}
