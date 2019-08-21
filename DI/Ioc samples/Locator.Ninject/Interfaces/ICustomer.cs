using System;
using System.Collections.Generic;
using System.Linq;

namespace Locator.NInject
{
    public interface ICustomer
    {
        void UpdateCustomerOrder(string customer, string product);
    }
}
