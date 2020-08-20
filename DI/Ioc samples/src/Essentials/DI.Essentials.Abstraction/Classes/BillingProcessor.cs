using System;
using DI.Essentials.Abstraction.Interfaces;

namespace DI.Essentials.Abstraction.Classes
{
    public class BillingProcessor : IBillingProcessor
    {
        void IBillingProcessor.ProcessPayment(string customer, string creditCard, double price)
        {
            // perform billing gateway processing
            Console.WriteLine(string.Format("Payment processed for customer '{0}' on credit card '{1}' for {2:c}.", customer, creditCard, price));
        }
    }
}
