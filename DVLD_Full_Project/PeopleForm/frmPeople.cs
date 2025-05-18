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
    public partial class frmPeople : Form
    {
        private DataTable _dtPeople;
        public frmPeople()
        {
            InitializeComponent();
        }
        private void _RefreashData()
        {
            _dtPeople = clsPerson.GetAllPeople();
            dataGridView1.DataSource = _dtPeople;
            labNum.Text = _dtPeople.Rows.Count.ToString();
        }
        private void frmPeople_Load(object sender, EventArgs e)
        {
            _RefreashData();
        }
        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex==0)
            {
                textBox1.Visible = false;
                _RefreashData();
                return;
            }
            textBox1.Visible = true;
        }
        private void btAdd_Click(object sender, EventArgs e)
        {
            frmAddOrEditPerson frm = new frmAddOrEditPerson();
            frm.ShowDialog();
            _RefreashData();
        }

        private void addNewPersonToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmAddOrEditPerson frm = new frmAddOrEditPerson();
            frm.ShowDialog();

            _RefreashData();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddOrEditPerson frm = new frmAddOrEditPerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreashData();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
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
            frmCardDetailsPerson frm = new frmCardDetailsPerson((int)dataGridView1.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _RefreashData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView view = _dtPeople.DefaultView;
            if (textBox1.Text == "")
            {
                _RefreashData();
            }
            else if (cmbFilter.SelectedItem == null)
            {
                MessageBox.Show("Please select a filter first.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    string filterColumn = cmbFilter.SelectedItem.ToString();

                    if (_dtPeople.Columns[filterColumn].DataType == typeof(string))
                    {
                        view.RowFilter = $"[{filterColumn}] LIKE '%{textBox1.Text}%'";
                    }
                    else
                    {
                        // For non-string columns, use an equality filter or other appropriate logic
                        if (int.TryParse(textBox1.Text, out int numericValue))
                        {
                            view.RowFilter = $"[{filterColumn}] = {numericValue}";
                        }
                    }
                }
                catch (Exception ex)
                {
                    _RefreashData();
                    MessageBox.Show($"Error filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            labNum.Text =view.Count.ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
