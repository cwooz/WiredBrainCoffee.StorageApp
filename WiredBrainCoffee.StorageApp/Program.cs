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
            RemoveEmployee(employeeRepository, 4);
            GetEmployeeById(employeeRepository, 2);
            WriteAllToConsole(employeeRepository);


            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
            //organizationRepository.PrintToConsole();
            WriteAllToConsole(organizationRepository);
        }

        private static void WriteAllToConsole(IReadRepository<IEntity> repository)
        {
            var items = repository.GetAll();
            foreach (var item in items)
            {
                Console.WriteLine(item);
            }
        }

        private static void GetEmployeeById(IRepository<Employee> employeeRepository, int id)
        {
            var employee = employeeRepository.GetById(id);
            Console.WriteLine($"Employee with Id of 2: {employee.FirstName} {employee.LastName}");
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            employeeRepository.Add(new Employee { FirstName = "Anna", LastName = "Roberts" });
            employeeRepository.Add(new Employee { FirstName = "Julia", LastName = "Stevens" });
            employeeRepository.Add(new Employee { FirstName = "Thomas", LastName = "Rollo" });
            employeeRepository.Add(new Employee { FirstName = "Tobe", LastName = "Removed" });
            employeeRepository.Save();
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            organizationRepository.Add(new Organization { Name = "Some Company" });
            organizationRepository.Add(new Organization { Name = "Another Company" });
            organizationRepository.Add(new Organization { Name = "Different Company" });
            organizationRepository.Save();
        }

        private static void RemoveEmployee(IRepository<Employee> employeeRepository, int id)
        {
            var employeeToBeRemoved = employeeRepository.GetById(id);
            employeeRepository.Remove(employeeToBeRemoved);
            employeeRepository.Save();
        }
    }
}
