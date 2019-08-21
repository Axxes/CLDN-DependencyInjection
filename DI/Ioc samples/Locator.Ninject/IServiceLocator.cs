using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locator.NInject
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
        object GetInstance(Type type);
        IEnumerable<T> GetAll<T>();
    }
}
