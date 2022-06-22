ADONET_Employee_Payroll.EmployeeRepo payroll = new ADONET_Employee_Payroll.EmployeeRepo();
ADONET_Employee_Payroll.PayrollModelClass modelClass = new ADONET_Employee_Payroll.PayrollModelClass();
payroll.ConnectionOfDatabase();
//payroll.CreateNewContact();
//payroll.updateDetails();
payroll.deleteEmployeeDetails();
payroll.RetrieveDataFromDatabase();