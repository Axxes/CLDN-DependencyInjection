using System;

namespace DI.Essentials.PoorMansContainer.DIContainer
{
    public class ContainerItem
    {
        public Type AbstractionType { get; set; }
        public Type ConcreteType { get; set; }
    }
}
