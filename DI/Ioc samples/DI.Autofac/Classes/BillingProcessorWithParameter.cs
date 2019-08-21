using System;

namespace DI
{
    public class BillingProcessorWithParameter : IBillingProcessor
    {
        private readonly string _creditCardNumber = string.Empty;

        public BillingProcessorWithParameter(string creditCardNumber)
        {
            _creditCardNumber = creditCardNumber;
        }
        public void ProcessPayment(string customer, string creditCard, double price)
        {
            Console.WriteLine(string.Format("Billing for credit cards only!!! Payment processed for customer '{0}' on credit card '{1}' for {2:c}.", customer, _creditCardNumber, price));
        }
    }
}
