using System;
using SystemDot.Core;
using SystemDot.Ioc.ObjectBuilding;

namespace SystemDot.Ioc
{
    public class ConcreteInstance
    {
        ObjectBuilder objectBuilder;
        object cached;

        public static T Create<T>(IocContainer iocContainer)
        {
            return Create(typeof(T), iocContainer).As<T>();
        }

        public static object Create(Type type, IocContainer iocContainer)
        {
            return FromType(type, iocContainer).Resolve();
        }

        public static ConcreteInstance FromFactory(Func<object> instanceFactory, Type concrete, IocContainer container)
        {
            return new ConcreteInstance(new FromFactoryObjectBuilder(instanceFactory, concrete, container));
        }

        public static ConcreteInstance FromType(Type concrete, IocContainer container)
        {
            return new ConcreteInstance(new FromTypeObjectBuilder(concrete, container));
        }

        ConcreteInstance(ObjectBuilder objectBuilder)
        {
            this.objectBuilder = objectBuilder;
        }

        public void DecorateWith<TDecorator>()
        {
            objectBuilder = objectBuilder.DecorateWith<TDecorator>();
        }

        public object Resolve()
        {
            return cached ?? (cached = objectBuilder.Create());
        }
    }
}