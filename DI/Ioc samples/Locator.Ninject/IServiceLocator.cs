using System;
using System.Collections.Generic;

namespace Locator.NInject
{
    public interface IServiceLocator
    {
        T GetInstance<T>();
        object GetInstance(Type type);
        IEnumerable<T> GetAll<T>();
    }
}
