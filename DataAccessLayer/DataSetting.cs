using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    internal class DataSetting
    {
        static public string ConnctionName = ConfigurationManager.AppSettings["ConnctionString"]
            = ConfigurationManager.ConnectionStrings["ConnctionString"].ConnectionString;
    }
}
