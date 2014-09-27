using System;

namespace SystemDot.Ioc.ObjectBuilding
{
    public class FromFactoryObjectBuilder : ObjectBuilder
    {
        readonly Func<object> objectFactory;
        readonly Type type;

        public FromFactoryObjectBuilder(Func<object> objectFactory, Type type, IIocContainer iocContainer)
            : base(iocContainer)
        {
            this.objectFactory = objectFactory;
            this.type = type;
        }

        public override object Create()
        {
            return objectFactory.Invoke();
        }

        public override Type GetInnerMostType()
        {
            return type;
        }

        public override string ToString()
        {
            return type.Name;
        }
    }
}