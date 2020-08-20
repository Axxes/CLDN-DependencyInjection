namespace DI
{
    public class Commerce3
    {
        public Commerce3(IProcessorLocator processorLocator)
        {
            _ProcessorLocator = processorLocator;
        }

        private readonly IProcessorLocator _ProcessorLocator;

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
        }
    }
}
