using System;
using DI.Essentials.PoorMansContainer.Interfaces;

namespace DI.Essentials.PoorMansContainer.Classes
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