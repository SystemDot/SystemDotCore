using System;
using System.Reflection;

namespace SystemDot.Ioc.ObjectBuilding
{
    public class DecoratorObjectBuilder : FromTypeObjectBuilder
    {
        readonly ObjectBuilder inner;
        readonly Type decoratedType;

        public DecoratorObjectBuilder(
            Type decoratorType, 
            ObjectBuilder inner, 
            Type decoratedType, 
            IIocContainer iocContainer)
            : base(decoratorType, iocContainer)
        {
            this.inner = inner;
            this.decoratedType = decoratedType;
        }

        protected override object ResolveParameter(Type parameterType)
        {
            return parameterType.GetTypeInfo().IsAssignableFrom(decoratedType.GetTypeInfo())
                ? inner.Create() 
                : base.ResolveParameter(parameterType);
        }

        public override Type GetInnerMostType()
        {
            return inner.GetInnerMostType();
        }

        public override string ToString()
        {
            return string.Format("{0} decorates {1}", base.ToString(), decoratedType.Name);
        }
    }
}