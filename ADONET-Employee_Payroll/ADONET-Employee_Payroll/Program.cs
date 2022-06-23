ADONET_Employee_Payroll.EmployeeRepo payroll = new ADONET_Employee_Payroll.EmployeeRepo();
ADONET_Employee_Payroll.PayrollModelClass modelClass = new ADONET_Employee_Payroll.PayrollModelClass();
payroll.ConnectionOfDatabase();
Console.WriteLine("Enter your option to perform\n1. Create New Employee Details\n2. Update the Details\n3. View the Employee Details\n4. Delete the Details using name");
int input = Convert.ToInt32(Console.ReadLine());
switch (input)
{
    case 1:
        payroll.CreateNewContact();
        payroll.RetrieveDataFromDatabase();
        break;
    case 2:
        payroll.updateDetails();
        payroll.RetrieveDataFromDatabase();
        break;
    case 3:
        payroll.RetrieveDataFromDatabase();
        break;
    case 4:
        payroll.RetrieveDataFromDatabase();
        payroll.DeleteEmployeeDetails();
        payroll.RetrieveDataFromDatabase();
        break;
    default:
        Console.WriteLine("Invalid Input");
        break;
}