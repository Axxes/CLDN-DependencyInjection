using System.Collections.Generic;
using System.Linq;
using DI.Scenarios.WebAPI.Models;

namespace DI.Scenarios.WebAPI.Infra
{
    public class CustomerRepository : ICustomerRepository
    {
        public Customer GetById(int id)
        {
            var customers = GetAll();
            return customers.FirstOrDefault(item => item.Id == id);
        }

        public List<Customer> GetAll()
        {
            var customers = new List<Customer>()
                {
                    new Customer() { Id = 1, Name = "Miguel A. Castro", Email = "miguel@dotnetdude.com", Twitter = "@miguelcastro67" },
                    new Customer() { Id = 2, Name = "John V. Petersen", Email = "johnvpetersen@gmail.com", Twitter = "@johnvpetersen" },
                };

            return customers;
        }
    }
}