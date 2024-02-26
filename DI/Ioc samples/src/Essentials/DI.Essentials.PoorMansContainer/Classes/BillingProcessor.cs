using System;
using DI.Essentials.PoorMansContainer.Interfaces;

namespace DI.Essentials.PoorMansContainer.Classes
{
    public class BillingProcessor : IBillingProcessor
    {

        void IBillingProcessor.ProcessPayment(string customer, string creditCard, double price)
        {
            // perform billing gateway processing
            Console.WriteLine($"Payment processed for customer '{customer}' on credit card '{creditCard}' for {price:c}.");
        }
    }
}
