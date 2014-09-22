using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;

namespace SystemDot.Ioc
{
    public class IocContainer : IIocContainer
    {
        readonly Dictionary<Type, ConcreteInstance> components = new Dictionary<Type, ConcreteInstance>();

        public IocContainer()
        {
            RegisterInstance<IIocContainer>(() => this);
        }

        public void RegisterInstance<TPlugin>(Func<TPlugin> instanceFactory) where TPlugin : class
        {
            if (ComponentExists<TPlugin>()) return;
            components[typeof(TPlugin)] = ConcreteInstance.FromFactory(instanceFactory, typeof(TPlugin), this);
        }

        public void RegisterInstance<TPlugin, TConcrete>()
            where TPlugin : class
            where TConcrete : class
        {
            RegisterInstance(typeof(TPlugin), typeof(TConcrete));
        }

        public void RegisterInstance(Type plugin, Type concrete)
        {
            if (ComponentExists(plugin)) return;
            components[plugin] = ConcreteInstance.FromType(concrete, this);
        }

        public bool ComponentExists<TPlugin>() 
        {
            return ComponentExists(typeof(TPlugin));
        }

        public bool ComponentExists(Type toCheck)
        {
            return components.ContainsKey(toCheck);
        }

        public IEnumerable<Type> GetAllRegisteredTypes()
        {
            return components.Keys;
        }

        public TPlugin Resolve<TPlugin>()
        {
            return (TPlugin)Resolve(typeof(TPlugin));
        }

        public object Resolve(Type type)
        {
            try
            {
                if (!components.ContainsKey(type)) 
                    throw new TypeNotRegisteredException(type);

                ConcreteInstance concreteType = components[type];

                return concreteType.Resolve();
            }
            catch(Exception ex)
            {
                throw new CannotResolveTypeException(type, ex);
            }
        }

        public T Create<T>()
        {
            return ConcreteInstance.Create<T>(this);
        }

        public object Create(Type type)
        {
            return ConcreteInstance.Create(type, this);
        }

        public void RegisterDecorator<TDecorator, TComponent>()
        {
            components[typeof (TComponent)].DecorateWith<TDecorator>();
        }

        public void RegisterOpenTypeDecorator(Type componentType, Type openDecoratorType)
        {
            components[componentType].DecorateWith(openDecoratorType.MakeGenericTypeFrom(componentType));
        }
    }
}