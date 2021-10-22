using System;
using WiredBrainCoffee.StorageApp.Data;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //var employeeRepository = new ListRepository<Employee>();
            //AddEmployees(employeeRepository);
            //GetEmployeeById(employeeRepository);

            //var organizationRepository = new ListRepository<Organization>();
            //AddOrganizations(organizationRepository);
            
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            AddEmployees(employeeRepository);
            GetEmployeeById(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
        }

        private static void GetEmployeeById(ListRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id of 2: {employee.FirstName}");
        }

        private static void AddEmployees(ListRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Tobe", LastName = "Removed" });
            employeeRepository.Add(new Employee { FirstName = "Julia", LastName = "Stevens" });
            employeeRepository.Add(new Employee { FirstName = "Anna", LastName = "Roberts" });
            employeeRepository.Add(new Employee { FirstName = "Thomas", LastName = "Rollo" });

            employeeRepository.Save();
        }

        private static void AddOrganizations(ListRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Some Company" });
            organizationRepository.Add(new Organization { Name = "Another Company" });
            organizationRepository.Add(new Organization { Name = "Different Company" });

            organizationRepository.Save();
        }
    }
}
