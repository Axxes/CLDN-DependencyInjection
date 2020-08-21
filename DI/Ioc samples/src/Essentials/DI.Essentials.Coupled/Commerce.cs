using DI.Essentials.Coupled.Classes;

namespace DI.Essentials.Coupled
{
    public class Commerce
    {
        public Commerce()
        {
            _billingProcessor = new BillingProcessor();
            _customer = new Customer();
            _notifier = new Notifier();
            _logger = new Logger();
        }

        private readonly BillingProcessor _billingProcessor;
        private readonly Customer _customer;
        private readonly Notifier _notifier;
        private readonly Logger _logger;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            _logger.Log("Billing processed");
            _customer.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            _logger.Log("Customer updated");
            _notifier.SendReceipt(orderInfo);
            _logger.Log("Receipt sent");
        }
    }
}
