namespace DI
{
    public class Commerce5
    {
        public Commerce5(IBillingProcessor billingProcessor, ICustomerProcessor customer, INotificationProcessor notifier, ILoggingProcessor logger)
        {
            _BillingProcessor = billingProcessor;
            _Customer = customer;
            _Notifier = notifier;
            _Logger = logger;
        }

        private readonly IBillingProcessor _BillingProcessor;
        private readonly ICustomerProcessor _Customer;
        private readonly INotificationProcessor _Notifier;
        private readonly ILoggingProcessor _Logger;

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
