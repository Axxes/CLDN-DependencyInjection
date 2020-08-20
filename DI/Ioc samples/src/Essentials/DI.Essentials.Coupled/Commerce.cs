using DI.Essentials.Coupled.Classes;

namespace DI.Essentials.Coupled
{
    public class Commerce
    {
        public Commerce()
        {
            _BillingProcessor = new BillingProcessor();
            _Customer = new Customer();
            _Notifier = new Notifier();
            _Logger = new Logger();
        }

        private readonly BillingProcessor _BillingProcessor;
        private readonly Customer _Customer;
        private readonly Notifier _Notifier;
        private readonly Logger _Logger;

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
