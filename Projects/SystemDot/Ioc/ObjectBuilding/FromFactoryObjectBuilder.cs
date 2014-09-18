using System;

namespace SystemDot.Ioc.ObjectBuilding
{
    public class FromFactoryObjectBuilder : IObjectBuilder
    {
        readonly Func<object> objectFactory;

        public FromFactoryObjectBuilder(Func<object> objectFactory)
        {
            this.objectFactory = objectFactory;
        }

        public object Create()
        {
            return objectFactory.Invoke();
        }
    }
}