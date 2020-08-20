using System;

namespace DI
{
    public class Commerce4
    {
        public Commerce4(IProcessorLocator2 processorLocator, ISingleTester singleTester)
        {
            _ProcessorLocator = processorLocator;
            _SingleTester = singleTester;
        }

        private readonly IProcessorLocator2 _ProcessorLocator;
        private readonly ISingleTester _SingleTester;

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

            _SingleTester.DisplayCounter();

            _ProcessorLocator.ReleaseScope();
        }
    }

    public interface ISingleTester
    {
        void DisplayCounter();
    }

    public class SingleTester : ISingleTester
    {
        private int _Counter = 0;

        public void DisplayCounter()
        {
            _Counter++;

            Console.WriteLine("Counter inside class 'SingleTester' is now: {0}", _Counter);
        }
    }
}
