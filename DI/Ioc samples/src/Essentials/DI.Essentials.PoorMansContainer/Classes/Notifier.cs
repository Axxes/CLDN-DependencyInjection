using System;
using DI.Essentials.PoorMansContainer.Interfaces;

namespace DI.Essentials.PoorMansContainer.Classes
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