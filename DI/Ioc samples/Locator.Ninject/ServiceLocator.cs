﻿using System;

namespace Locator.NInject
{
    public static class ServiceLocator
    {
        private static IServiceLocator _current;
        public static IServiceLocator Current
        {
            get
            {
                return _current;
            }
        }

        public static void SetServiceLocator(Func<IServiceLocator> create)
        {
            if (create == null) throw new ArgumentNullException("create");
            _current = create();
        }
    }
}