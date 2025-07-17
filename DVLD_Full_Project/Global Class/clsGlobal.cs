using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinessLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace DVLD_Full_Project
{
    public static class clsGlobal
    {
        private static string _CreateDataString(string username, string password)
        {
            return $"{username}#//#{password}";
        }
        private static string[] _SplitSpecialString(string UserNameAndPassWordString)
        {
            return UserNameAndPassWordString.Split(new string[] { "#//#" }, StringSplitOptions.None);
        }
        public static clsUser CurrentUser { get; set; }
        private static string filePath = "D:\\Courses\\NewProjects\\FullProject\\DVLD_Full_Project\\UserLogin.txt";
        public static bool GetStoredCredential(ref string UserName, ref string Password)
        {
            if (File.Exists(filePath) && new FileInfo(filePath).Length > 0)
            {
                string[] Data = _SplitSpecialString(File.ReadAllText(filePath));
                UserName = Data[0];
                Password = Data[1];
                return true;
            }
            return false;
        }
        public static void SaveRememberMeCredentials(string UserName, string Password)
        {

            File.WriteAllText(filePath,_CreateDataString(UserName, Password));
        }
        public static void SaveRememberMeCredentials()
        {
            File.WriteAllText(filePath, string.Empty);
        }
    }
}
