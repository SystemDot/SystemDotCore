using System;
using System.Collections.Generic;

namespace SystemDot.Ioc.Multiples
{
    public class MultipleDecoratorToDecorateRegistration
    {
        readonly IIocContainer container;
        readonly IEnumerable<Type> typesToDecorate;

        public MultipleDecoratorToDecorateRegistration(IIocContainer container, IEnumerable<Type> typesToDecorate)
        {
            this.container = container;
            this.typesToDecorate = typesToDecorate;
        }

        public void WithOpenTypeDecorator(Type openDecoratorType)
        {
            typesToDecorate.ForEach(t => container.RegisterOpenTypeDecorator(t, openDecoratorType));
        }

        public void WithOpenTypeDecorators(params Type[] openTypeDeccorators)
        {
            openTypeDeccorators.ForEach(WithOpenTypeDecorator);
        }
    }
}