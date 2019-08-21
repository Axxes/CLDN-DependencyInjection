namespace DI.Abstraction
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
