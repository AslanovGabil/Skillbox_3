using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp5.Models;

namespace WpfApp5.Services
{
    public class SalaryService
    {
        private int salaryIntern = 500;
        public void SalaryAppropriationForAllOrganization(Organization organization)
        {
            int sum = 0;
            foreach (var item in organization.Vedomstvos)
            {
               sum+= SalaryVedomstvo(item);
            }
            int salary = sum / 100 * 15;
            organization.ExtBoss.Salary=salary > 1300 ? salary : 1300;
            salary += organization.ExtBoss.Salary;
            organization.Boss.Salary = salary > 1300 ? salary : 1300;

        }

        public int SalaryVedomstvo(Vedomstvo vedomstvo)
        {
            int sum = 0;
            foreach (var item in vedomstvo.Departments)
            {
                sum+= SalaryDepartment(item);
            }
            int salary = sum / 100 * 15;
            vedomstvo.VedomstvoBoss.Salary = salary > 1300 ? salary : 1300;
            return salary + vedomstvo.VedomstvoBoss.Salary;
        }

        public int SalaryDepartment(Department department)
        {
                int sum = 0;
            if (department.Departments.Count==0)
            {
                for (int i = 0; i < department.Employees.Count; i++)
                {
                    var item=department.Employees[i];
                    if (item.Status == Status.Intern)
                    {
                        item.Salary = salaryIntern;
                    }
                    if (item.Status == Status.Employee)
                    {
                        item.Salary = item.Rate * item.WorkingHours;
                    }
                }
                sum = department.Employees.Sum(e => e.Salary);
            }
            else
            {
                foreach (var item in department.Departments)
                {
                    sum+=SalaryDepartment(item);
                }
            }

                var departmentBoss = department.Employees.FirstOrDefault(e => e.Status == Status.DepartmentBoss);
                int salary = sum / 100 * 15;
                departmentBoss.Salary = salary > 1300 ? salary : 1300;
                return salary + departmentBoss.Salary;
        }
    }
}
