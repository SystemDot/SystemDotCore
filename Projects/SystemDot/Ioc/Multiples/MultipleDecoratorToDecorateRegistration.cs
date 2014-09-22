using System;
using System.Collections.Generic;
using SystemDot.Core.Collections;

namespace SystemDot.Ioc
{
    public class MultipleDecoratorWithRegistration
    {
        readonly IIocContainer container;
        readonly IEnumerable<Type> typesToDecorate;

        public MultipleDecoratorWithRegistration(IIocContainer container, IEnumerable<Type> typesToDecorate)
        {
            this.container = container;
            this.typesToDecorate = typesToDecorate;
        }

        public void WithOpenTypeDecorator(Type openDecoratorType)
        {
            typesToDecorate.ForEach(t => container.RegisterOpenTypeDecorator(t, openDecoratorType));
        }
    }
}