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
        public void RetrieveDataFromDatabase()
        {
            PayrollModelClass profile = new PayrollModelClass();
            connect.Open();
            using (connect)
            {
                string query = "Select * from Employee_PayRoll";

                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("ID\t\tName\t\tSalary\t\t\tDate\n");
                    while (reader.Read())
                    {
                        profile.ID = reader.GetInt32(0);
                        profile.Name = reader.GetString(1);
                        profile.Salary = reader.GetDouble(2);
                        profile.Start = reader.GetDateTime(3);
                        Console.WriteLine(profile.ID + "\t\t" + profile.Name + "\t\t" + profile.Salary + "\t\t" + profile.Start);
                    }
                }
                else
                {
                    Console.WriteLine("Records not found in Database.");
                }
                reader.Close();

            }
            connect.Close();
        }
    }
}
