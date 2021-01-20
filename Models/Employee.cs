using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Models
{
    public class Employee
    {
        public string Lastame { get; set; }
        public string FirstName { get; set; }
        public string Adress { get; set; }
        public string Phone { get; set; }
        public Status Status { get; set; }
        public int WorkingHours { get; set; }
        public int Rate { get; set; }
        public int Salary { get; set; }
        public DateTime Birth { get; set; }
    }
    public enum Status{
        Intern,
        Employee,
        ExtBoss,
        Boss,
        VedomstvoBoss,
        DepartmentBoss
    }
}
