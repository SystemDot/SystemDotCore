using System;
using SystemDot.Ioc.ObjectBuilding;

namespace SystemDot.Ioc
{
    public class ConcreteInstance
    {
        ObjectBuilder objectBuilder;
        object cached;
        public Type ActualConcreteType { get; private set; }

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
            return new ConcreteInstance(concrete, new FromFactoryObjectBuilder(instanceFactory, concrete, container));
        }

        public static ConcreteInstance FromType(Type concrete, IocContainer container)
        {
            return new ConcreteInstance(concrete, new FromTypeObjectBuilder(concrete, container));
        }

        ConcreteInstance(Type actualConcreteType, ObjectBuilder objectBuilder)
        {
            ActualConcreteType = actualConcreteType;
            this.objectBuilder = objectBuilder;
        }

        public void DecorateWith<TDecorator>()
        {
            objectBuilder = objectBuilder.DecorateWith(typeof(TDecorator));
        }

        public void DecorateWith(Type decoratorType)
        {
            objectBuilder = objectBuilder.DecorateWith(decoratorType);
        }

        public object Resolve()
        {
            return cached ?? (cached = objectBuilder.Create());
        }

        public override string ToString()
        {
            return objectBuilder.ToString();
        }
    }
}