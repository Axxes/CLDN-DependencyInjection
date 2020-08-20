using System.Collections.Generic;

namespace DI
{
    public class Commerce7
    {
        public Commerce7(IProcessorLocator processorLocator,
            IEnumerable<IPostOrderPlugin> plugins)
        {
            _ProcessorLocator = processorLocator;
            _Plugins = plugins;
        }

        private readonly IProcessorLocator _ProcessorLocator;
        private readonly IEnumerable<IPostOrderPlugin> _Plugins;

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
