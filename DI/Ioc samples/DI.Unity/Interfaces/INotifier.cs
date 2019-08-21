namespace DI.Unity
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
