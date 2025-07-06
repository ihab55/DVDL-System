using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BussinessLayer;
using DVLD_Full_Project.Global_Class;
using DVLD_Full_Project.Properties;

namespace DVLD_Full_Project
{
    public partial class frmAddUpdatePerson : Form
    {
        public delegate void DataBackEventHandler(object sender, int PersonID);
        public event DataBackEventHandler DataBack;
        private enum _enFormMode
        {
            _enAddPeople = 0,
            _enEditPerson = 1
        }
        private _enFormMode _Mode = _enFormMode._enAddPeople;

        private int _PersonID;
        private clsPerson _Person;
        public frmAddUpdatePerson()
        {
            InitializeComponent();
            _Mode = _enFormMode._enAddPeople;
        }
        public frmAddUpdatePerson(int PersonID)
        {
            InitializeComponent();
            _Mode = _enFormMode._enEditPerson;
            _PersonID = PersonID;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _FillComboBoxCountry()
        {
            DataTable dtCountries = clsCountry.GetAllCountry();
            foreach(DataRow CountryName in dtCountries.Rows)
            {
                cmbCountry.Items.Add(CountryName["CountryName"]);
            }
            cmbCountry.SelectedItem = "Egypt";
        }
        private void _LoadData()
        {
            _Person = clsPerson.Find(_PersonID);
            clabID.Text = _Person.PersonID.ToString();
            txtFirst.Text = _Person.FirstName;
            txtSecond.Text = _Person.SecondName;
            txtThird.Text = _Person.ThirdName;
            txtLast.Text = _Person.LastName;
            txtNationalNum.Text = _Person.NationalNo;
            dtDateOfBirth.Value = _Person.DateOfBirth;
            rbFemale.Checked = _Person.Gendor == 1?true:false;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            cmbCountry.SelectedItem = _Person.CountryInfo.Name;
            if (!string.IsNullOrEmpty(_Person.ImagePath) && File.Exists(_Person.ImagePath))
            {
                pbPerson.ImageLocation = _Person.ImagePath;
                linRemove.Enabled = true;
            }
            else
            {
                pbPerson.Image = _Person.Gendor == 0 ? Resources.person_boy : Resources.person_girl;
                linRemove.Enabled = false;
            }
        }
        private bool HandelPersonImage()
        {
            if (pbPerson.ImageLocation != _Person.ImagePath)
            {
                if (_Person.ImagePath != "")
                {
                    File.Delete(_Person.ImagePath);
                }
                if (pbPerson.ImageLocation != null )
                {
                    string SourceImageFile = pbPerson.ImageLocation;
                    if (clsUtil.CopyImageToProjectImagesFolder(ref SourceImageFile))
                    {
                        _Person.ImagePath = SourceImageFile;
                        return true;
                    }
                }
                else
                {
                    _Person.ImagePath = string.Empty;
                }
            }
            return true;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                return;
            }
            if (_Mode == _enFormMode._enAddPeople) _Person = new clsPerson();
            if (!HandelPersonImage()) return;

            _Person.FirstName = txtFirst.Text.Trim();
            _Person.SecondName = txtSecond.Text.Trim();
            _Person.ThirdName = txtThird.Text.Trim();
            _Person.LastName = txtLast.Text.Trim();
            _Person.NationalNo = txtNationalNum.Text.Trim();
            _Person.DateOfBirth = dtDateOfBirth.Value;
            _Person.Gendor = rbMale.Checked ?(short) 0 :(short) 1;
            _Person.Address = txtAddress.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.NationalityCountryID = clsCountry.Find(cmbCountry.SelectedItem.ToString()).ID;
            _Person.ImagePath = pbPerson.ImageLocation == null?"": pbPerson.ImageLocation;

            if (_Person.Save())
            {
                clabID.Text = _Person.PersonID.ToString();
                label1.Text = "Update Person";
                _Mode = _enFormMode._enEditPerson;
                _PersonID = _Person.PersonID;
                MessageBox.Show("Person information saved successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DataBack?.Invoke(this,this._PersonID);
            }
            else
            {
                MessageBox.Show("Failed to save person information.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }    
        }

        private void frmAddUpdatePerson_Load(object sender, EventArgs e)
        {
            _FillComboBoxCountry();

            if (_Mode == _enFormMode._enEditPerson)
            {
                label1.Text = "Update Person";
                _LoadData();
            }
        }
        private void linRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
            {
            pbPerson.ImageLocation = null;
            pbPerson.Image = rbMale.Checked ? Resources.person_boy : Resources.person_girl;
            linRemove.Enabled = false;
        }
        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbPerson.ImageLocation == null)
            {
                pbPerson.Image = rbMale.Checked? Resources.person_boy: Resources.person_girl;
            }
        }
        private void textFirst_Validating(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox) sender;
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(textBox, "This field is required.");
            }
            else
            {
                errorProvider1.SetError(textBox, string.Empty);
            }
        }
        private void txtNoNum_Validating(object sender, CancelEventArgs e) {
            if (string.IsNullOrEmpty(txtNationalNum.Text))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNum, "This field must not fill.");
            }
            else if (clsPerson.IsExist(txtNationalNum.Text) && txtNationalNum.Text!=_Person.NationalNo)
            {
                e.Cancel = true;
                errorProvider1.SetError(txtNationalNum, "This National Number already exists.");
            }
            else {
                errorProvider1.SetError(txtNationalNum, string.Empty);
            }

        }
        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text) || clsValidatoin.ValidateEmail(txtEmail.Text))
            {
                errorProvider1.SetError(txtEmail, string.Empty);
            }
            else
            {
                e.Cancel = true;
                errorProvider1.SetError(txtEmail, "Invalid email format.");
            }
        }

        private void linUpload_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            openFileDialog1.Title = "Select Person Image";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory = true;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string selectedFile = openFileDialog1.FileName;
                pbPerson.ImageLocation = selectedFile;
                linRemove.Enabled = true;
            }
            }
    }
}
