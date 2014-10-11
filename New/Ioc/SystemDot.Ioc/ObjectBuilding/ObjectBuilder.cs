using System;

namespace SystemDot.Ioc.ObjectBuilding
{
    public abstract class ObjectBuilder
    {
        readonly IIocContainer iocContainer;

        protected ObjectBuilder(IIocContainer iocContainer)
        {
            this.iocContainer = iocContainer;
        }

        public abstract object Create();
        
        public ObjectBuilder DecorateWith(Type decoratorType)
        {
            return new DecoratorObjectBuilder(decoratorType, this, GetInnerMostType(), iocContainer);
        }

        public abstract Type GetInnerMostType();
    }
}