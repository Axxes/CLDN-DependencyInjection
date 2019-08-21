using System;
using System.Collections.Generic;
using System.Linq;

namespace Locator.NInject
{
    public interface IBillingProcessor
    {
        void ProcessPayment(string customer, string creditCard, double price);
    }
}
