using Autofac.Core.Activators.Reflection;
using System;
using System.Linq;
using System.Reflection;

namespace DI
{
    public class AwesomeConstructorFinder : IConstructorFinder
    {
        ConstructorInfo[] IConstructorFinder.FindConstructors(Type targetType)
        {
            ConstructorInfo constructorToResolve = null;

            var constructors = targetType.GetConstructors();

            foreach (var constructor in constructors)
            {
                var attributes = constructor.GetCustomAttributes(typeof(AwesomeConstructorAttribute), false);
                if (attributes != null && attributes.Count() > 0)
                {
                    constructorToResolve = constructor;
                    break;
                }
            }

            return new ConstructorInfo[] { constructorToResolve };
        }
    }
}
