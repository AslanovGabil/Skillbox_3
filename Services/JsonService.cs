using Bogus;
using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp5.Models;

namespace WpfApp5.Services
{
    public class JsonService
    {
        public void CreateAndSaveOrganization()
        {
            Organization organization = new Organization();
         
            organization.Name = "Skillbox";
            var employees = GetEmployees();
            Random random = new Random();
            organization.Boss = employees[random.Next(0,100)];
            organization.Boss.Status = Status.Boss;
            organization.ExtBoss = employees[random.Next(0, 100)];
            organization.ExtBoss.Status = Status.ExtBoss;
            List<Vedomstvo> vedomstvos = new List<Vedomstvo>()
            {
                new Vedomstvo()
                {
                    Name="Vedomstvo1"
                },
                 new Vedomstvo()
                {
                    Name="Vedomstvo2"
                },
                  new Vedomstvo()
                {
                    Name="Vedomstvo3"
                },
            };

        }
        public async Task CreateAndSaveEmployees()
        {
            List<Employee> employees = new List<Employee>();
            Faker faker = new Faker();
           
            //(Bar)values.GetValue(random.Next(values.Length));
            for (int i = 0; i < 100; i++)
            {
                var random = new Random() ;
               
                Employee employee = new Employee()
                {
                    Lastame = faker.Person.LastName,
                    FirstName = faker.Person.FirstName,
                    Adress = faker.Address.StreetAddress(true),
                    Birth = faker.Person.DateOfBirth,
                    Phone = faker.Person.Phone,
                    Rate= random.Next(5,30),
                    WorkingHours = random.Next( 30,80),
                    Status= i/5==0?Status.Intern:Status.Employee

                };
                
                employees.Add(employee);
            }
            using (FileStream createStream = File.Open(@"..\Json\Employees.json", FileMode.OpenOrCreate,FileAccess.ReadWrite,FileShare.ReadWrite))
            {
          
                await JsonSerializer.SerializeAsync(createStream, employees);
                
            }
        }

        public List<Employee> GetEmployees()
        {
            var jsonString = File.ReadAllText(@"..\..\Json\Employees.json");

           

            return 
                JsonSerializer.Deserialize<List<Employee>>(jsonString).ToList();
        }
    }
}
