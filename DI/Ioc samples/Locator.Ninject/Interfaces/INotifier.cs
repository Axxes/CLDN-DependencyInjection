using System;
using System.Collections.Generic;
using System.Linq;

namespace Locator.NInject
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
