using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp5.Models
{
    public class Department
    {
      
        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
