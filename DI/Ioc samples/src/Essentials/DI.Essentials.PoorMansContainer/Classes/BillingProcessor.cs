using System;
using DI.Essentials.PoorMansContainer.Interfaces;

namespace DI.Essentials.PoorMansContainer.Classes
{
    public class BillingProcessor : IBillingProcessor
    {
        private readonly ILogger _logger;

        public BillingProcessor(ILogger logger)
        {
            _logger = logger;
        }

        void IBillingProcessor.ProcessPayment(string customer, string creditCard, double price)
        {
            // perform billing gateway processing
            _logger.Log($"Payment processed for customer '{customer}' on credit card '{creditCard}' for {price:c}.");
        }
    }
}
