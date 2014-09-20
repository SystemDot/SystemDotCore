using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.Ioc.ObjectBuilding;

namespace SystemDot.Ioc
{
    public class ConcreteInstance
    {
        readonly List<Type> decorators;
        readonly IObjectBuilder objectBuilder;
        object cached;

        public static T Create<T>(IocContainer iocContainer)
        {
            return Create(typeof(T), iocContainer).As<T>();
        }

        public static object Create(Type type, IocContainer iocContainer)
        {
            return FromType(type, iocContainer).Resolve();
        }
        public static ConcreteInstance FromFactory(Func<object> instanceFactory)
        {
            return new ConcreteInstance(new FromFactoryObjectBuilder(instanceFactory));
        }

        public static ConcreteInstance FromType(Type concrete, IocContainer container)
        {
            return new ConcreteInstance(new FromTypeObjectBuilder(concrete, container));
        }

        ConcreteInstance(IObjectBuilder objectBuilder)
        {
            this.objectBuilder = objectBuilder;
            decorators = new List<Type>();
        }

        public void DecorateWith<T>()
        {
            decorators.Add(typeof(T));
        }

        public object Resolve()
        {
            if(decorators.Any()) return Activator.CreateInstance(decorators.First());

            return cached ?? (cached = objectBuilder.Create());
        }
    }
}