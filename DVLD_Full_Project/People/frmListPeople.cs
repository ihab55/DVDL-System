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
    public partial class frmListPeople : Form
    {
        private static DataTable _dtAllPeople;
        private DataTable _dtPeople ;
        public frmListPeople()
        {
            InitializeComponent();
        }
        private void _RefreashData()
        {
            _dtAllPeople = clsPerson.GetAllPeople();
            _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo",
                                                       "FirstName", "SecondName", "ThirdName", "LastName",
                                                       "GendorCaption", "DateOfBirth", "CountryName",
                                                       "Phone", "Email");
            dataGridView1.DataSource = _dtPeople;
            labNum.Text = _dtPeople.Rows.Count.ToString();
        }
        private void frmPeople_Load(object sender, EventArgs e)
        {
            _RefreashData();
            cmbFilter.SelectedIndex = 0;
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Columns[0].HeaderText = "Person ID";
                dataGridView1.Columns[0].Width = 80;

                dataGridView1.Columns[1].HeaderText = "National No.";
                dataGridView1.Columns[1].Width = 95;


                dataGridView1.Columns[2].HeaderText = "First Name";
                dataGridView1.Columns[2].Width = 90;

                dataGridView1.Columns[3].HeaderText = "Second Name";
                dataGridView1.Columns[3].Width = 105;


                dataGridView1.Columns[4].HeaderText = "Third Name";
                dataGridView1.Columns[4].Width = 90;

                dataGridView1.Columns[5].HeaderText = "Last Name";
                dataGridView1.Columns[5].Width = 90;

                dataGridView1.Columns[6].HeaderText = "Gendor";
                dataGridView1.Columns[6].Width = 70;

                dataGridView1.Columns[7].HeaderText = "Date Of Birth";
                dataGridView1.Columns[7].Width = 100;

                dataGridView1.Columns[8].HeaderText = "Nationality";
                dataGridView1.Columns[8].Width = 70;


                dataGridView1.Columns[9].HeaderText = "Phone";
                dataGridView1.Columns[9].Width = 80;


                dataGridView1.Columns[10].HeaderText = "Email";
                dataGridView1.Columns[10].Width = 105;
            }
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Focus();
            textBox1.Visible = !(cmbFilter.SelectedIndex == 0);
            _RefreashData();
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();
            _RefreashData();
        }
        private void addNewPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson();
            frm.ShowDialog();

            _RefreashData();
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddUpdatePerson frm = new frmAddUpdatePerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreashData();
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this person?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsPerson.Delete((int)dataGridView1.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Deleted Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreashData();
                }
                else
                {
                    MessageBox.Show("Error in Deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void sendMailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this futer Will Implament in futur", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("this futer Will Implament in futur", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmShowPersonInfo frm = new frmShowPersonInfo((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterColumn = ""; 
            switch (cmbFilter.Text)
            {
                case "Person ID":
                    FilterColumn = "PersonID";
                    break;

                case "National No.":
                    FilterColumn = "NationalNo";
                    break;

                case "First Name":
                    FilterColumn = "FirstName";
                    break;

                case "Second Name":
                    FilterColumn = "SecondName";
                    break;

                case "Third Name":
                    FilterColumn = "ThirdName";
                    break;

                case "Last Name":
                    FilterColumn = "LastName";
                    break;

                case "Nationality":
                    FilterColumn = "CountryName";
                    break;

                case "Gendor":
                    FilterColumn = "GendorCaption";
                    break;

                case "Phone":
                    FilterColumn = "Phone";
                    break;

                case "Email":
                    FilterColumn = "Email";
                    break;

                default:
                    FilterColumn = "None";
                    break;

            }
            if (textBox1.Text.Trim() == "" || FilterColumn == "None")
            {
                _dtPeople.DefaultView.RowFilter = "";
                labNum.Text = dataGridView1.Rows.Count.ToString();
                return;
            }

            if (FilterColumn == "PersonID")
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] = {1}", FilterColumn, textBox1.Text.Trim());
            else
                _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'", FilterColumn, textBox1.Text.Trim());

            labNum.Text = dataGridView1.Rows.Count.ToString();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cmbFilter.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
    }
}
