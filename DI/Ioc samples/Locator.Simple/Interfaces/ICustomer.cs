using System;
using System.Collections.Generic;
using System.Linq;

namespace Locator.Simple
{
    public interface ICustomer
    {
        void UpdateCustomerOrder(string customer, string product);
    }
}
