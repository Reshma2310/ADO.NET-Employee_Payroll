using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADONET_Employee_Payroll
{
    public class PayrollModelClass
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }
        public DateTime Start { get; set; }
        public string Gender { get; set; }
        public long Phone { get; set; }
        public string Address { get; set; }
    }
}
