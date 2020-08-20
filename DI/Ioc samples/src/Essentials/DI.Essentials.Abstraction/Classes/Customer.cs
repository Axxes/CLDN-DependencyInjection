using System;
using DI.Essentials.Abstraction.Interfaces;

namespace DI.Essentials.Abstraction.Classes
{
    public class Customer : ICustomer
    {
        void ICustomer.UpdateCustomerOrder(string customer, string product)
        {
            // update customer record with purchase
            Console.WriteLine(string.Format("Customer record for '{0}' updated with purchase of product '{1}'.", customer, product));
        }
    }
}