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
            var employeeRepository = new SqlRepository<Employee>(new StorageAppDbContext());
            AddEmployees(employeeRepository);
            GetEmployeeById(employeeRepository);
            RemoveEmployee(employeeRepository, 1);
            employeeRepository.Save();

            //var employeeListRepository = new ListRepository<Employee>();
            //AddEmployees(employeeListRepository);
            //GetEmployeeById(employeeListRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            organizationRepository.Save();
        }

        private static void RemoveEmployee(IRepository<Employee> employeeRepository, int id)
        {
            var employeeToBeRemoved = employeeRepository.GetById(id);
            employeeRepository.Remove(employeeToBeRemoved);
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository)
        {
            var employee = employeeRepository.GetById(2);
            Console.WriteLine($"Employee with Id of 2: {employee.FirstName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Tobe", LastName = "Removed" });
            employeeRepository.Add(new Employee { FirstName = "Julia", LastName = "Stevens" });
            employeeRepository.Add(new Employee { FirstName = "Anna", LastName = "Roberts" });
            employeeRepository.Add(new Employee { FirstName = "Thomas", LastName = "Rollo" });
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Some Company" });
            organizationRepository.Add(new Organization { Name = "Another Company" });
            organizationRepository.Add(new Organization { Name = "Different Company" });
        }
    }
}
