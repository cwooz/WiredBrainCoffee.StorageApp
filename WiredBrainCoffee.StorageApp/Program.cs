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
            employeeRepository.ItemAdded += EmployeeRepository_ItemAdded;
            AddEmployees(employeeRepository);
            AddManagers(employeeRepository);
            RepositoryExtensions.LineBreak();
            RemoveEmployee(employeeRepository, 1);
            GetEmployeeById(employeeRepository, 2);
            WriteAllToConsole(employeeRepository);
            RepositoryExtensions.LineBreak();

            //Action<Organization> organizationAdded = OrganizationAdded;
            var organizationRepository = new SqlRepository<Organization>(new StorageAppDbContext());
            organizationRepository.ItemAdded += OrganizationRepository_ItemAdded;
            AddOrganizations(organizationRepository);
            RepositoryExtensions.LineBreak();
            WriteAllToConsole(organizationRepository);
        }

        private static void EmployeeRepository_ItemAdded(object? sender, Employee employee)
        {
            Console.WriteLine($"Employee added => {employee.FirstName} {employee.LastName}");
            //Console.WriteLine($"From => {sender}");
        }

        private static void OrganizationRepository_ItemAdded(object? sender, Organization organization)
        {
            Console.WriteLine($"Organization added => {organization.Name}");
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
            employeeRepository.AddBatch(employees);
        }

        private static void AddOrganizations(IRepository<Organization> organizationRepository)
        {
            var organizations = new[]
            {
                new Organization { Name = "Some Company" },
                new Organization { Name = "Another Company" },
                new Organization { Name = "Different Company" }
            };
            organizationRepository.AddBatch(organizations);
        }

        private static void AddManagers(IWriteRepository<Manager> managerRepository)
        {
            var brianManager = new Manager { FirstName = "Brian", LastName = "Keller" };
            var brianManagerCopy = brianManager.Copy<Manager>();
            managerRepository.Add(brianManager);

            if (brianManagerCopy is not null)
            {
                brianManagerCopy.LastName += "_Copy";
                managerRepository.Add(brianManagerCopy);
            }

            managerRepository.Add(new Manager { FirstName = "William", LastName = "Barefield" });
            managerRepository.Save();
        }
    }
}
