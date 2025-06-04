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
    public partial class ucApplicationInfo : UserControl
    {
        public ucApplicationInfo()
        {
            InitializeComponent();
        }
        public void FillApplication(int id)
        {
            clsApplication GetApp = clsApplication.FindApp(id);
            if (GetApp != null)
            {
                txtID.Text = GetApp.ID.ToString();
                txtStattus.Text = GetApp.Status.ToString();
                txtFees.Text = GetApp.Fees.ToString();
                txtType.Text = GetApp.AppTypeInfo.Title;
                txtApplicant.Text = GetApp.PersonInfo.FullName();
                txtDate.Text = GetApp.Date.ToString("dd/MM/yyyy");
                txtStatusDate.Text = GetApp.StatusDate.ToString("dd/MM/yyyy");
                txtCreatedBy.Text = GetApp.CreatedbyInfo.UserName;
                txtApplicant.Tag = GetApp.PersonInfo.Id;
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCardDetailsPerson person = new frmCardDetailsPerson((int)txtApplicant.Tag);
            person.ShowDialog();
        }
    }
}
