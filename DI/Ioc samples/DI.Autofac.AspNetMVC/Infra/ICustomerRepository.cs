using DI.Autofac.AspNetMVC.Models;
using System.Collections.Generic;

namespace DI.Autofac.AspNetMVC.Infra
{
    public interface ICustomerRepository
    {
        Customer GetById(int id);
        List<Customer> GetAll();
        void Update(Customer customer);
    }
}
