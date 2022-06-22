using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Employee_Payroll
{
    public class EmployeeRepo
    {
        public static string dbpath = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service;Integrated Security=True";
        SqlConnection connect = new SqlConnection(dbpath);        
        public void ConnectionOfDatabase()
        {
            try
            {
                connect.Open();
                using (connect)
                {
                    Console.WriteLine("Database connectivity successful.");
                }
                connect.Close();
            }
            catch
            {
                Console.WriteLine("Database connectivity failed");
            }
        }
    }
}
