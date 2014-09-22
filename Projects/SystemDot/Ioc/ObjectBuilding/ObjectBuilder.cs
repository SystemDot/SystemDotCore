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
        
        public ObjectBuilder DecorateWith<T>()
        {
            return new DecoratorObjectBuilder<T>(this, GetInnerMostType(), iocContainer);
        }

        public abstract Type GetInnerMostType();
    }
}