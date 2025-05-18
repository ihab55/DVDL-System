using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;

namespace BussinessLayer
{
    public class clsManageTests
    {
        public int id;
        public string Title;
        public string Description;
        public decimal Fees;
        public static DataTable GetAllManageTest()
        {
            return clsManageTestsData.GetAllManageTests();
        }
        private clsManageTests(int id, string title, string description, decimal fees)
        {
            this.id = id;
            this.Title = title;
            this.Description = description;
            this.Fees = fees;
        }
        public static clsManageTests Find(int id)
        {
            string title = "";
            string description = "";
            decimal fees = 0;
            if (clsManageTestsData.GetManageTestByID(id, ref title,ref description ,ref fees))
            {
                return new clsManageTests(id, title, description, fees);
            }
                return null;
        }
        private bool UpdateManageTest()
        {
            return clsManageTestsData.UpdateManageTestType(this.id, this.Title, this.Description, this.Fees);
        }
        public bool save()
        {
            return UpdateManageTest();
        }
    }
}
