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
            var abstractionType = typeof(T);
            var concreteType = typeof(U);

            Register(abstractionType, concreteType);
        }

        public void Register(Type abstractionType, Type concreteType)
        {
            if (!abstractionType.IsInterface)
                throw new ApplicationException("First generic argument must be an interface type.");

            _Registrations.Add(new ContainerItem() { AbstractionType = abstractionType, ConcreteType = concreteType });
        }

        private readonly List<ContainerItem> _Registrations;

        public T CreateType<T>() where T : class
        {
            var type = typeof(T);

            return (T)GetConcreteType(type);
        }

        public object CreateType(Type type)
        {
            return GetConcreteType(type);
        }

        private object GetConcreteType(Type typeToResolve)
        {
            var containerItem = _Registrations.Where(item => item.AbstractionType.Equals(typeToResolve)).FirstOrDefault();
            if (containerItem != null)
                return GetTypeInstance(containerItem.ConcreteType);
            else
                return GetTypeInstance(typeToResolve);
        }

        private object GetTypeInstance(Type type)
        {
            object instance = null;

            var constructors = type.GetConstructors();
            if (constructors.Length > 0)
            {
                var constructor = constructors[0];

                var constructorArguments = new List<object>();
                var parameters = constructor.GetParameters();
                foreach (var parameter in parameters)
                {
                    object parameterInstance = null;
                    if (parameter.ParameterType.IsInterface)
                        // recursion happens here
                        parameterInstance = GetConcreteType(parameter.ParameterType);

                    constructorArguments.Add(parameterInstance);
                }

                instance = Activator.CreateInstance(type, constructorArguments.ToArray());
            }

            return instance;
        }
    }
}
