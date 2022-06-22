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
                    Console.WriteLine("Database connectivity successful");
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
            PayrollModelClass model = new PayrollModelClass();
            SqlConnection connect = new SqlConnection(dbpath);
            connect.Open();
            using (connect)
            {
                string query = "Select * from Employee_PayRoll";

                SqlCommand command = new SqlCommand(query, connect);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    Console.WriteLine("ID\tName\t\tSalary\t\tDate\t\t\t\tGender\n");
                    while (reader.Read())
                    {
                        model.ID = reader.GetInt32(0);
                        model.Name = reader.GetString(1);
                        model.Salary = reader.GetDouble(2);
                        model.Start = reader.GetDateTime(3);
                        model.Gender = reader.GetString(4);
                        Console.WriteLine(model.ID + "\t" + model.Name + "\t\t" + model.Salary + "\t\t" + model.Start + "\t\t" + model.Gender);
                    }
                }
                else
                {
                    Console.WriteLine("Records not found in Database");
                }
                reader.Close();

            }
            connect.Close();
        }

        public void CreateNewContact()
        {
            SqlConnection connect = new SqlConnection(dbpath);
            using (connect)
                {
                connect.Open();
                ADONET_Employee_Payroll.PayrollModelClass model = new ADONET_Employee_Payroll.PayrollModelClass();
                Console.WriteLine("Enter Name");
                model.Name = Console.ReadLine();
                Console.WriteLine("Enter Salary");
                model.Salary = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Enter a Year,Month,Date");
                model.Start = DateTime.Now;
                Console.WriteLine("Enter Gender");
                model.Gender = Console.ReadLine();
                SqlCommand sql = new SqlCommand("SP_Employee_Payroll", connect);                    
                sql.CommandType = CommandType.StoredProcedure;
                sql.Parameters.AddWithValue("@NAME", model.Name);
                sql.Parameters.AddWithValue("@SALARY", model.Salary);
                sql.Parameters.AddWithValue("@START", model.Start);
                sql.Parameters.AddWithValue("@Gender", model.Gender);
                sql.ExecuteNonQuery();
                Console.WriteLine("Record created successfully.");
                connect.Close();                    
                }
        }
        public void updateDetails()
        {            
            SqlConnection connect = new SqlConnection(dbpath);
            try
            {
                using (connect)
                {
                    Console.WriteLine("Enter name of employee to update basic pay:");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter basic pay to update:");
                    decimal salary = Convert.ToDecimal(Console.ReadLine());
                    connect.Open();
                    string query = "update Employee_Payroll set salary =" + salary + "where name='" + name + "'";
                    SqlCommand command = new SqlCommand(query, connect);
                    command.ExecuteNonQuery();
                    Console.WriteLine("Details updated successfully.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Details are not updated");
            }
        }
        public void deleteEmployeeDetails()
        {
            SqlConnection connect = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Payroll_Service;Integrated Security=True");
            connect.Open();
            string query = @"DELETE FROM Employee_Payroll where ID = '20'";
            SqlCommand cmd = new SqlCommand(query, connect);
            object res = cmd.ExecuteScalar();
            connect.Close();

        }
    }
}
