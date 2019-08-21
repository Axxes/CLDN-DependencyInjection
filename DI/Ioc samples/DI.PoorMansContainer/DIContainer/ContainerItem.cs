using System;

namespace DI.PoorMansContainer
{
    public class ContainerItem
    {
        public Type AbstractionType { get; set; }
        public Type ConcreteType { get; set; }
    }
}
