using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer;
using Microsoft.Win32;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Full_Project
{
    public static class clsGlobal
    {
        public static clsUser CurrentUser { get; set; }
        public static bool GetStoredCredential(ref string UserName, ref string Password)
        {
            bool IsSave = false;
            string SubKeypath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            try
            {
                UserName = Registry.GetValue(SubKeypath, "UserName", UserName) as string;
                Password = Registry.GetValue(SubKeypath, "Password", Password) as string;
                IsSave = true;
            }
            catch (Exception ex) { IsSave = false; }
            return IsSave;
        }
        public static bool SaveRememberMeCredentials(string UserName, string Password)
        {
            bool IsSave = false;
            string SubKeypath = @"HKEY_CURRENT_USER\SOFTWARE\DVLD";
            try
            {
                Registry.SetValue(SubKeypath, "UserName", UserName, RegistryValueKind.String);
                Registry.SetValue(SubKeypath, "Password", Password, RegistryValueKind.String);
                IsSave = true;
            }
            catch (Exception ex) { IsSave = false; }
            return IsSave;
        }
    }
}
