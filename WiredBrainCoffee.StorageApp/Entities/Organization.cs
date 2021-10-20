using System;
using System.Collections.Generic;

namespace WiredBrainCoffee.StorageApp.Entities
{
    class Organization
    {
        public int Id { get; set; }

        public string? Name { get; set; }

        public override string ToString() => $"Id: {Id}, Name: {Name}";
    }
}
