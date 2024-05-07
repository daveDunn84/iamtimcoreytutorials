using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoLibrary
{
    public class SqlDataAccess : IDataAccess
    {
        public string LoadConnectionString(string name)
        {
            Console.WriteLine("Load Connection String");
            return "testConnectionString";
        }

        public void LoadData(string sql)
        {
            Console.WriteLine("Loading Microsoft SQL Data");
        }

        public void SaveData(string sql)
        {
            Console.WriteLine("Saving data to Microsoft SQL Server");
        }
    }
}
