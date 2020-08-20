using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DI.Essentials.PoorMansContainer.DIContainer
{
    public class Container
    {
        public Container()
        {
            _Registrations = new List<ContainerItem>();
        }

        public void Register<T, U>()
            where U : class, new()
        {
            throw new NotImplementedException();
        }

        public void Register(Type abstractionType, Type concreteType)
        {
            throw new NotImplementedException();
        }

        private readonly List<ContainerItem> _Registrations;

        public T CreateType<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public object CreateType(Type type)
        {
            throw new NotImplementedException();
        }

        private object GetConcreteType(Type typeToResolve)
        {
            throw new NotImplementedException();
        }

        private object GetTypeInstance(Type type)
        {
            throw new NotImplementedException();
        }
    }
}
