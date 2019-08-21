using System;
using System.Collections.Generic;
using System.Linq;

namespace Locator.Simple
{
    public interface INotifier
    {
        void SendReceipt(OrderInfo orderInfo);
    }
}
