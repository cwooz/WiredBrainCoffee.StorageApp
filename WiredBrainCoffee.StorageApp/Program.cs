using System;
using WiredBrainCoffee.StorageApp.Entities;
using WiredBrainCoffee.StorageApp.Repositories;

namespace WiredBrainCoffee.StorageApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var employeeRepository = new GenericRepository<Employee>();

            employeeRepository.Add(new Employee { Id = 01, FirstName = "Julia", LastName = "Stevens" });
            employeeRepository.Add(new Employee { Id = 02, FirstName = "Anna", LastName = "Roberts" });
            employeeRepository.Add(new Employee { Id = 03, FirstName = "Thomas", LastName = "Rollo" });

            employeeRepository.Save();


            var organizationRepository = new GenericRepository<Organization>();

            organizationRepository.Add(new Organization { Id = 01, Name = "Some Company" });
            organizationRepository.Add(new Organization { Id = 02, Name = "Another Company" });
            organizationRepository.Add(new Organization { Id = 03, Name = "Different Company" });

            organizationRepository.Save();
        }
    }
}
