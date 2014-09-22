using System;
using SystemDot.Core;

namespace SystemDot.Ioc
{
    public class MultipleDecoratorRegistration
    {
        readonly IIocContainer container;

        public MultipleDecoratorRegistration(IIocContainer container)
        {
            this.container = container;
        }

        public MultipleDecoratorWithRegistration ThatImplementOpenType(Type openType)
        {
            return new MultipleDecoratorWithRegistration(container, container.GetAllRegisteredTypes().WhereImplementsOpenType(openType));
        }
    }
}