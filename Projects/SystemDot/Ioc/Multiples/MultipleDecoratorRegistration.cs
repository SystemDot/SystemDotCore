using System;
using SystemDot.Core;

namespace SystemDot.Ioc.Multiples
{
    public class MultipleDecoratorRegistration
    {
        readonly IIocContainer container;

        public MultipleDecoratorRegistration(IIocContainer container)
        {
            this.container = container;
        }

        public MultipleDecoratorToDecorateRegistration ThatImplementOpenType(Type openType)
        {
            return new MultipleDecoratorToDecorateRegistration(container, container.GetAllRegisteredTypes().WhereImplementsOpenType(openType));
        }
    }
}