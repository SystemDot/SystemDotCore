using System;
using SystemDot.Ioc.ObjectBuilding;

namespace SystemDot.Ioc
{
    public class ConcreteInstance
    {
        readonly DependencyLifecycle lifecycle;
        ObjectBuilder objectBuilder;
        object cached;
        public Type ActualConcreteType { get; private set; }

        public static T Create<T>(IocContainer iocContainer)
        {
            return Create(typeof(T), iocContainer, DependencyLifecycle.SingletonInstance).As<T>();
        }

        public static object Create(Type type, IocContainer iocContainer, DependencyLifecycle lifecycle)
        {
            return FromType(type, iocContainer, lifecycle).Resolve();
        }

        public static ConcreteInstance FromFactory(Func<object> instanceFactory, Type concrete, IocContainer container)
        {
            return new ConcreteInstance(concrete, DependencyLifecycle.SingletonInstance, new FromFactoryObjectBuilder(instanceFactory, concrete, container));
        }

        public static ConcreteInstance FromType(Type concrete, IocContainer container, DependencyLifecycle lifecycle)
        {
            return new ConcreteInstance(concrete, lifecycle, new FromTypeObjectBuilder(concrete, container));
        }

        ConcreteInstance(Type actualConcreteType, DependencyLifecycle lifecycle, ObjectBuilder objectBuilder)
        {
            ActualConcreteType = actualConcreteType;
            this.lifecycle = lifecycle;
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
            return lifecycle == DependencyLifecycle.SingletonInstance 
                ? GetCachedInstance()
                : CreateInstance();
        }

        object GetCachedInstance()
        {
            return cached ?? (cached = CreateInstance());
        }

        object CreateInstance()
        {
            return objectBuilder.Create();
        }

        public override string ToString()
        {
            return objectBuilder.ToString();
        }
    }
}