namespace DI
{
    public interface INotificationProcessor
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
