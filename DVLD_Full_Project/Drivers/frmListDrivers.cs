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
    public partial class frmListDrivers : Form
    {
        private DataTable DataTable;
        public frmListDrivers()
        {
            InitializeComponent();
            cmbFilter.SelectedIndex = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cmbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFilter.SelectedIndex == 0)
            {
                textBox1.Visible = false;
                 dataGridView1.DataSource = DataTable = clsDriver.GetDriver();
                labNum.Text = dataGridView1.RowCount.ToString();
                return;
            }
            textBox1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            DataView view = DataTable.DefaultView;
            if (textBox1.Text != "")
            {
                try
                {
                    string filterColumn = cmbFilter.SelectedItem.ToString();

                    if (DataTable.Columns[filterColumn].DataType == typeof(string))
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
                    cmbFilter.SelectedIndex=0;
                    MessageBox.Show($"Error filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            labNum.Text = view.Count.ToString();
        }
    }
}
