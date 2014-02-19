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
            
            components[typeof(TPlugin)] = new ConcreteInstance(instanceFactory);
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
            components[plugin] = new ConcreteInstance(concrete);
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
            if (!components.ContainsKey(type))
                throw new TypeNotRegisteredException(string.Format(
                    IocContainerResources.TypeHasNotBeenRegisteredMessage, 
                    type.Name));

            var concreteType = components[type];

            if (concreteType.ObjectInstance != null)
                return concreteType.ObjectInstance;

            if (concreteType.ObjectFactory != null)
                return concreteType.SetObjectInstance(concreteType.ObjectFactory.Invoke());

            return Create(concreteType);
        }

        object Create(ConcreteInstance concreteType)
        {
            return concreteType.SetObjectInstance(Create(concreteType.ObjectType));
        }

        public T Create<T>()
        {
            return Create(typeof (T)).As<T>();
        }

        public object Create(Type type)
        {
            var constructorInfo = type
                .GetAllConstructors()
                .First();

            var parameters = constructorInfo.GetParameters();

            var parameterInstances = new object[parameters.Count()];

            for (var i = 0; i < parameters.Count(); i++) parameterInstances[i] = Resolve(parameters[i].ParameterType);

            return constructorInfo.Invoke(parameterInstances);
        }
    }
}