using System;
using System.Collections.Generic;

namespace SystemDot.Ioc.Multiples
{
    public class MultipleDecoratorForAssembliesRegistration
    {
        readonly IIocContainer container;
        readonly IEnumerable<Type> types;

        public MultipleDecoratorForAssembliesRegistration(IIocContainer container, IEnumerable<Type> types)
        {
            this.container = container;
            this.types = types;
        }

        public MultipleDecoratorToDecorateRegistration ThatImplementOpenType(Type openType)
        {
            return new MultipleDecoratorToDecorateRegistration(container, types.WhereImplementsOpenType(openType));
        }
    }
}