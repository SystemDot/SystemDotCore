using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SystemDot.Reflection;

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
            RegisterInstance(typeof(TPlugin), typeof(TConcrete), DependencyLifecycle.SingletonInstance);
        }

        public void RegisterInstance<TPlugin, TConcrete>(DependencyLifecycle lifecycle)
            where TPlugin : class
            where TConcrete : class
        {
            RegisterInstance(typeof(TPlugin), typeof(TConcrete), lifecycle);
        }

        public void RegisterInstance(Type plugin, Type concrete)
        {
            RegisterInstance(plugin, concrete, DependencyLifecycle.SingletonInstance);
        } 
        
        void RegisterInstance(Type plugin, Type concrete, DependencyLifecycle lifecycle)
        {
            if (ComponentExists(plugin)) return;
            components[plugin] = ConcreteInstance.FromType(concrete, this, lifecycle);
        }

        public bool ComponentExists<TPlugin>()
        {
            return ComponentExists(typeof(TPlugin));
        }

        public bool ComponentExists(Type toCheck)
        {
            return components.ContainsKey(toCheck);
        }

        public IEnumerable<RegisteredType> GetAllRegisteredTypes()
        {
            return components
                .Select(c => new RegisteredType(c.Key, c.Value.ActualConcreteType))
                .ToList();
        }

        public void Verify()
        {
            try
            {
                components.ToList().ForEach(pair => Resolve(pair.Key));
            }
            catch (Exception ex)
            {
                throw new ContainerUnverifiableException(ex);
            }
        }

        public TPlugin Resolve<TPlugin>()
        {
            return (TPlugin)Resolve(typeof(TPlugin));
        }

        public object Resolve(Type type)
        {
            try
            {
                return GetComponent(type).Resolve();
            }
            catch (Exception ex)
            {
                throw new CannotResolveTypeException(type, ex);
            }
        }

        ConcreteInstance GetComponent(Type type)
        {
            if (!ComponentExists(type)) CreateComponentIfConcrete(type);
            if (!ComponentExists(type)) throw new TypeNotRegisteredException(type);
            return components[type];
        }

        void CreateComponentIfConcrete(Type type)
        {
            if (!type.IsNormalConcrete()) return;
            components[type] = ConcreteInstance.FromType(type, this, DependencyLifecycle.SingletonInstance);
        }

        public T Create<T>()
        {
            return ConcreteInstance.Create<T>(this);
        }

        public object Create(Type type)
        {
            return ConcreteInstance.Create(type, this, DependencyLifecycle.SingletonInstance);
        }

        public void RegisterDecorator<TDecorator, TComponent>()
        {
            components[typeof(TComponent)].DecorateWith<TDecorator>();
        }

        public void RegisterOpenTypeDecorator(Type componentType, Type openDecoratorType)
        {
            components[componentType].DecorateWith(openDecoratorType.MakeGenericTypeFrom(componentType));
        }

        public string Describe()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < components.Count; i++)
            {
                var c = components.ElementAt(i);
                sb.AppendFormat("{0} Resolve with: {1}  Actual type: {2}", i, c.Key.Name, c.Value).AppendLine();
            }
            return sb.ToString();
        }
    }
}