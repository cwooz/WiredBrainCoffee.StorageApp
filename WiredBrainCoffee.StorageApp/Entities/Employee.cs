using System;
using System.Collections.Generic;
using System.Text;

namespace WiredBrainCoffee.StorageApp.Entities
{
    public class Employee
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public override string ToString() => $"Id: {Id}, FirstName: {FirstName}, LastName: {LastName}";
    }
}
