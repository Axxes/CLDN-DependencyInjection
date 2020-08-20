namespace DI
{
    public class Commerce10
    {
        public Commerce10(IBillingProcessor billingProcessor)
        {
            _BillingProcessor = billingProcessor;
        }

        private readonly IBillingProcessor _BillingProcessor;

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _BillingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
        }
    }
}
