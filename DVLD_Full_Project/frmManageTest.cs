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
    public partial class frmManageTest : Form
    {
        public frmManageTest()
        {
            InitializeComponent();
            _Refreash();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void _Refreash()
        {
            dataGridView1.DataSource = clsManageTests.GetAllManageTest();
            labNum.Text = dataGridView1.RowCount.ToString();
        }

        private void editApplicationTypeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmEditManageTest frmEdit = new frmEditManageTest((int)dataGridView1.CurrentRow.Cells[0].Value);
            frmEdit.ShowDialog();
            _Refreash();
        }

    }
}
