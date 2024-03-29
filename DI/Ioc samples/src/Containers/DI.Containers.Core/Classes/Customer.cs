using DI.Core.Interfaces;
using System;

namespace DI.Core.Classes
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