using DI.Core.Interfaces;

namespace DI.Core
{
    public class Commerce
    {
        public Commerce(IBillingProcessor billingProcessor, ICustomer customer, INotifier notifier, ILogger logger)
        {
            _BillingProcessor = billingProcessor;
            _Customer = customer;
            _Notifier = notifier;
            _Logger = logger;
        }

        private readonly IBillingProcessor _BillingProcessor;
        private readonly ICustomer _Customer;
        private readonly INotifier _Notifier;
        private readonly ILogger _Logger;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _BillingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _Logger.Log("Billing processed");
            _Customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _Logger.Log("Customer updated");
            _Notifier.SendReceipt(orderInfo);
            _Logger.Log("Receipt sent");
        }
    }
}
