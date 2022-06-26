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
        public void ConnectionOfDatabase()
        {
            try
            {
                SqlConnection connect = new SqlConnection(dbpath);
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
                    Console.WriteLine("ID\tName\t\t\tSalary\t\t\tDate\t\t\t\tGender\n");
                    while (reader.Read())
                    {
                        model.ID = reader.GetInt32(0);
                        model.Name = reader.GetString(1);
                        model.Salary = reader.GetDouble(2);
                        model.Start = reader.GetDateTime(3);
                        model.Gender = reader.GetString(4);
                        Console.WriteLine(model.ID + "\t" + model.Name + "\t\t\t" + model.Salary + "\t\t\t" + model.Start + "\t\t\t" + model.Gender);
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
                model.Start = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter Gender");
                model.Gender = Console.ReadLine();
                SqlCommand sql = new SqlCommand("SPEmployeePayRoll", connect);                    
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
        public void DeleteEmployeeDetails()
        {
            SqlConnection connect = new SqlConnection(dbpath);
            try
            {
                using (connect)
                {
                    connect.Open();
                    Console.WriteLine("Enter name of employee to delete from records:");
                    string name = Console.ReadLine();
                    string query = "delete from employee_payroll where name='" + name + "'";
                    SqlCommand command = new SqlCommand(query, connect);
                    command.ExecuteNonQuery();
                    connect.Close();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                connect.Close();
            }

        }
    }
}
