using System;

namespace SystemDot.Ioc.ObjectBuilding
{
    public class DecoratorObjectBuilder<TDecorator> : FromTypeObjectBuilder
    {
        readonly ObjectBuilder inner;
        readonly Type decoratedType;

        public DecoratorObjectBuilder(ObjectBuilder inner, Type decoratedType, IIocContainer iocContainer)
            : base(typeof(TDecorator), iocContainer)
        {
            this.inner = inner;
            this.decoratedType = decoratedType;
        }

        protected override object ResolveParameter(Type parameterType)
        {
            return parameterType == decoratedType 
                ? inner.Create() 
                : base.ResolveParameter(parameterType);
        }

        public override Type GetInnerMostType()
        {
            return inner.GetInnerMostType();
        }
    }
}