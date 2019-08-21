using System;
using System.Collections;
using System.Collections.Generic;

namespace Locator.Simple
{
    /// <summary>
    /// This class is a very simple implementation of service locator.
    /// </summary>
    internal class SimpleServiceLocator : ISimpleServiceLocator
    {
        private readonly Dictionary<Type, object> _services = new Dictionary<Type, object>();

        /// <summary>
        /// This property is purely for testing this class.
        /// </summary>
        internal IDictionary<Type, object> Services
        {
            get
            {
                return _services;
            }
        }

        public void Set<T>(T service)
        {
            if (!typeof(T).IsInterface)
            {
                throw new ServiceLocatorException("Only interfaces can be registered with instances.");
            }

            lock (((ICollection)_services).SyncRoot)
            {
                if (_services.ContainsKey(typeof(T)))
                {
                    _services[typeof(T)] = service;
                }
                else
                {
                    _services.Add(typeof(T), service);
                }
            }
        }

        public T Get<T>()
        {
            lock (((ICollection)_services).SyncRoot)
            {
                if (!_services.ContainsKey(typeof(T)))
                {
                    throw new ServiceLocatorException("Service not found.");
                }

                var instance = _services[typeof(T)];

                return (T)instance;
            }
        }
    }
}
