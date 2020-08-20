using DI.Core.Interfaces;
using System;

namespace DI.Core.Classes
{
    public class Notifier : INotifier
    {
        void INotifier.SendReceipt(OrderInfo orderInfo)
        {
            // send email to customer with receipt
            Console.WriteLine(string.Format("Receipt sent to customer '{0}' via email.", orderInfo.CustomerName));
        }
    }
}