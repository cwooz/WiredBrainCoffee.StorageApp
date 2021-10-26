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
            AddManagers(employeeRepository);
            RemoveEmployee(employeeRepository, 1);
            GetEmployeeById(employeeRepository, 2);
            WriteAllToConsole(employeeRepository);

            var organizationRepository = new ListRepository<Organization>();
            AddOrganizations(organizationRepository);
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

        private static void RemoveEmployee(IRepository<Employee> employeeRepository, int id)
        {
            var employeeToBeRemoved = employeeRepository.GetById(id);
            employeeRepository.Remove(employeeToBeRemoved);
            employeeRepository.Save();
        }

        private static void AddEmployees(IRepository<Employee> employeeRepository)
        {
            var employees = new[]
            {
                new Employee { FirstName = "Tobe", LastName = "Removed" },
                new Employee { FirstName = "Anna", LastName = "Roberts" },
                new Employee { FirstName = "Julia", LastName = "Stevens" },
                new Employee { FirstName = "Thomas", LastName = "Rollo" }
            };
            AddBatch(employeeRepository, employees);
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            var managers = new[]
            {
                new Manager { FirstName = "Brian", LastName = "Keller" },
                new Manager { FirstName = "William", LastName = "Barfield" }
            };
            AddBatch(managerRepository, managers);
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization { Name = "Some Company" },
                new Organization { Name = "Another Company" },
                new Organization { Name = "Different Company" }
            };
            AddBatch(organizationRepository, organizations);
        }

        private static void AddBatch<T>(IWriteRepository<T> repository, T[] items)
        {
            foreach (var item in items)
            {
                repository.Add(item);
            }
            repository.Save();
        }
    }
}
