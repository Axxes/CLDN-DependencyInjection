using System.Collections.Generic;
using System.Linq;
using DI.Scenarios.WebAPI.Models;

namespace DI.Scenarios.WebAPI.Infra
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new()
        {
            new Customer() { Id = 1, Name = "Miguel A. Castro", Email = "miguel@dotnetdude.com", Twitter = "@miguelcastro67" },
            new Customer() { Id = 2, Name = "John V. Petersen", Email = "johnvpetersen@gmail.com", Twitter = "@johnvpetersen" },
        };
        
        public Customer GetById(int id)
        {
            var customer = _customers.FirstOrDefault(item => item.Id == id);

            _customers.Remove(customer);

            return customer;
        }

        public List<Customer> GetAll()
        {
            return _customers;
        }
    }
}