using System.Collections.Generic;

namespace DI
{
    public class Commerce8
    {
        public Commerce8()
        { }

        public IProcessorLocator _ProcessorLocator { get; set; }
        public IEnumerable<IPostOrderPlugin> _Plugins { get; set; }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            var billingProcessor = _ProcessorLocator.GetProcessor<IBillingProcessor>();
            var customerProcessor = _ProcessorLocator.GetProcessor<ICustomerProcessor>();
            var notificationProcessor = _ProcessorLocator.GetProcessor<INotificationProcessor>();
            var loggingProcessor = _ProcessorLocator.GetProcessor<ILoggingProcessor>();

            billingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
            loggingProcessor.Log("Billing processed");
            customerProcessor.UpdateCustomerOrder(orderInfo.CustomerName, orderInfo.Product);
            loggingProcessor.Log("Customer updated");
            notificationProcessor.SendReceipt(orderInfo);
            loggingProcessor.Log("Receipt sent");

            foreach (var plugin in _Plugins)
            {
                plugin.DoSomething();
            }
        }
    }
}
