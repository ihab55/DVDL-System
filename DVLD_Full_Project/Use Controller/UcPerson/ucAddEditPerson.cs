using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;
using DVLD_Full_Project.Properties;
using System.IO;
using System.Runtime.CompilerServices;

namespace DVLD_Full_Project.Use_Controller
{
    public partial class ucAddEditPerson : UserControl
    {
        private string _NationalNum ="";
        public bool GetData (ref clsPerson person)
        {
            if (_CheakAllTxtNotEmpty())
            {
                person.FirstName = textFirst.Text;
                person.SecondName = textsecond.Text;
                person.ThirdName = textthird.Text;
                person.LastName = textlast.Text;
                person.NationalID = txtNationalNum.Text;
                person.DateOfBirth = dtDateOfBirth.Value;
                person.Gendor = (rbFemale.Checked) ? 1 : 0;
                person.Phone = txtPhone.Text;
                person.Email = txtEmail.Text;
                person.CountryId =(cmbCountry.SelectedIndex==-1)? 51:cmbCountry.SelectedIndex+1;
                person.Address = txtAddress.Text;
                if (pbPerson.Tag == "Delete" && person.ImagePath != "")
                {
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    string PathDeltePhoto = person.ImagePath;
                    person.ImagePath = "";
                    File.Delete(PathDeltePhoto);
                }
                if (openFileDialog1.FileName != "")
                {
                    if (person.ImagePath!="")
                    {
                        GC.Collect();
                        GC.WaitForPendingFinalizers();
                        File.Delete(person.ImagePath);
                    }
                    string destFolder = @"D:\Courses\NewProjects\FullProject\DVLD_Full_Project\\PersonPhoto";
                    string destFileName = $"{Guid.NewGuid()}{Path.GetExtension(openFileDialog1.FileName)}"; // "guid.jpg"
                    person.ImagePath = Path.Combine(destFolder, destFileName); 
                    File.Copy(openFileDialog1.FileName, person.ImagePath);
                }
                
                return true;
            }
            return false;
        }
        public ucAddEditPerson()
        {
            InitializeComponent();
        }
        // for get all country
        private void _LoadComboBox()
        {
            DataTable dt = clsCountry.GetAllCountry();
            foreach (DataRow dr in dt.Rows)
            {
                cmbCountry.Items.Add(dr["CountryName"]);
            }
        }
        //Chang Photo for male and female
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (openFileDialog1.FileName=="")
            {
                pbPerson.Image =( rbMale.Checked) ? Resources.person_boy : Resources.person_girl;
            }

        }

        private bool _IsContainNumber(string txt)
        {
            return Regex.IsMatch(txt,@"\d"); //return true if have num
        }
        //Cheak for All Name that not Contain Num
        private void _TextValidForName(TextBox text,CancelEventArgs e)
        {
            if (_IsContainNumber(text.Text))
            {
                e.Cancel = true;
                text.Focus();
                ep.SetError(text, "Name Not valied");
            }
            else
            {
                e.Cancel= false;
                ep.Clear();
            }
        }
        
        private void RequiredText(object sender, CancelEventArgs e)
        {
            _TextValidForName((TextBox)sender, e);
        }

        public void FillCardForEdit(clsPerson person)
        {
            clabID.Text = person.Id.ToString();
            textFirst.Text = person.FirstName;
            textsecond.Text = person.SecondName;
            textthird.Text = person.ThirdName;
            textlast.Text = person.LastName;
            _NationalNum = txtNationalNum.Text = person.NationalID ;
            txtPhone.Text = person.Phone;
            txtEmail.Text = person.Email;
            txtAddress.Text = person.Address;
            dtDateOfBirth.Value = person.DateOfBirth;
            cmbCountry.SelectedIndex = cmbCountry.FindString(clsCountry.Find(person.CountryId).CountryName);
            rbMale.Checked = (person.Gendor == 0);
            rbFemale.Checked = (person.Gendor == 1);
            if (person.ImagePath != "")
            {
               pbPerson.Image = Image.FromFile(person.ImagePath);
               linRemove.Visible = true;
            }
        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                if (txtEmail.Text.Contains("@"))
                {
                    e.Cancel = false;
                    ep.Clear();
                }
                else
                {
                    e.Cancel = true;
                    txtEmail.Focus();
                    ep.SetError(txtEmail, "Email Must contain @");
                }
            }
            
        }
        private bool _CheakAllTxtNotEmpty()
        {
            ep.Clear();
            bool Isfounded = true;
            if (string.IsNullOrEmpty(textFirst.Text))
            {
                ep.SetError(textFirst, "Enter a Value");
                Isfounded = false;
            }
            if (string.IsNullOrEmpty(textsecond.Text))
            {
                ep.SetError(textsecond, "Enter a Value");
                Isfounded = false;
            }
            if (string.IsNullOrEmpty(textlast.Text))
            {
                ep.SetError(textlast, "Enter a Value");
                Isfounded = false;
            }
            if (string.IsNullOrEmpty(txtNationalNum.Text))
            {
                ep.SetError(txtNationalNum, "Enter a Value");
                Isfounded = false;
            }
            if (string.IsNullOrEmpty(txtPhone.Text))
            {
                ep.SetError(txtPhone, "Enter a Value");
                Isfounded = false;
            }
            if (string.IsNullOrEmpty(txtAddress.Text))
            {
                ep.SetError(txtAddress, "Enter a Value");
                Isfounded = false;
            }
            return Isfounded;

        }
        
        //Cheak if this National Id is Exists
        private void txtNationalNum_Validating(object sender, CancelEventArgs e)
        {
            if (clsPerson.IsExist(txtNationalNum.Text.ToString()) && _NationalNum.ToLower() != txtNationalNum.Text.ToLower())
            {
                e.Cancel = true;
                txtNationalNum.Focus();
                ep.SetError(txtNationalNum, "Num Id is Exsits");
            }
            else
            {
                e.Cancel = false;
                ep.Clear();
            }
        }

        private void linUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif;*.tiff";
            openFileDialog1.Title = "Select an Image File";
            openFileDialog1.InitialDirectory = "D:\\PopPhoto";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPerson.Image = Image.FromFile(openFileDialog1.FileName);
                linRemove.Visible = true;
                pbPerson.Tag = "OK";
            }
        }

        private void ucAddEditPerson_Load(object sender, EventArgs e)
        {
            _LoadComboBox();
            cmbCountry.SelectedText = "Egypt";
            dtDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            linRemove.Visible = false;
        }

        private void linRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPerson.Image = (rbMale.Checked) ? Resources.person_boy : Resources.person_girl;
            linRemove.Visible = false;
            pbPerson.Tag = "Delete";
        }
    }
}
