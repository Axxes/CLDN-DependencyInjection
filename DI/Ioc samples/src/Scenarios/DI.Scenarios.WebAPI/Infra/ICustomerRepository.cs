using System.Collections.Generic;
using DI.Scenarios.WebAPI.Models;

namespace DI.Scenarios.WebAPI.Infra
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        List<Customer> GetAll();
    }

    public interface ICustomerRepositoryWrapper : ICustomerRepository
    {
        
    }
}
