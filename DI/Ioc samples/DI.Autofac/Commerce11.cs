namespace DI
{
    public class Commerce11
    {
        IBillingProcessor _BillingProcessor;
        public Commerce11(IBillingProcessor billingProcessor)
        {
            _BillingProcessor = billingProcessor;
        }

        public void ProcessOrder(OrderInfo orderInfo)
        {
            _BillingProcessor.ProcessPayment(orderInfo.CustomerName, orderInfo.CreditCard, orderInfo.Price);
        }
    }
}
