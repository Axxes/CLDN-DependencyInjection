using System;

namespace DI.Essentials.Coupled.Classes
{
    public class Notifier
    {
        public void SendReceipt(OrderInfo orderInfo)
        {
            // send email to customer with receipt
            Console.WriteLine(string.Format("Receipt sent to customer '{0}' via email.", orderInfo.CustomerName));
        }
    }
}
