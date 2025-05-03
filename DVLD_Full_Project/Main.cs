using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Full_Project
{
    public partial class Main : Form
    {
        public Main(bool Reminder = false)
        {
            InitializeComponent();
        }

        private void applicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implamtion yet","Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void peopleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPeople frm = new frmPeople();
            frm.ShowDialog();
        }

        private void driversToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implamtion yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void usersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implamtion yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void accountSettingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not Implamtion yet", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            Program.IsRestart = true;
        }
    }
}
