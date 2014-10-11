using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SystemDot.Ioc;
using SystemDot.Reflection;

namespace SystemDot.Bootstrapping
{
    public class BootstrapBuilderComponentRunner
    {
        readonly IIocContainer container;
        readonly BootstrapBuilder builder;

        public BootstrapBuilderComponentRunner(IIocContainer container, BootstrapBuilder builder)
        {
            this.container = container;
            this.builder = builder;
        }

        public void Run()
        {
            GetApplication().GetAllTypes()
                .ThatImplement<IBootstrapBuilderComponent>()
                .ForEach(RunComponent);
        }

        IApplication GetApplication()
        {
            return container.Resolve<IApplication>();
        }

        void RunComponent(Type componentType)
        {
            RunComponent(Activator.CreateInstance(componentType).As<IBootstrapBuilderComponent>());
        }

        void RunComponent(IBootstrapBuilderComponent component)
        {
            component.Configure(builder);
        }
    }

    internal static class TypeExtensions
    {
        public static IEnumerable<Type> ThatImplement<TType>(this IEnumerable<Type> types)
        {
            return types.WhereNormalConcrete().WhereImplements<TType>();
        }

        static IEnumerable<Type> WhereImplements<TImplemented>(this IEnumerable<Type> types)
        {
            return types.Where(t =>
                t.GetNonBaseInterfaces().Contains(typeof(TImplemented))
                || t.GetBaseInterfaces().Contains(typeof(TImplemented)));
        }

        static IEnumerable<Type> GetNonBaseInterfaces(this Type type)
        {
            IEnumerable<Type> baseInterfaces = GetBaseInterfaces(type);
            return type.GetInterfaces().Where(t => !baseInterfaces.Contains(t));
        }

        static IEnumerable<Type> GetBaseInterfaces(this Type type)
        {
            var types = new List<Type>();
            Type baseType = type.GetTypeInfo().BaseType;

            if (baseType == typeof(MemberInfo)) return types;

            while (baseType != null)
            {
                types.AddRange(baseType.GetInterfaces());
                baseType = baseType.GetTypeInfo().BaseType;
                if (baseType == typeof(MemberInfo)) return types;
            }
            return types;
        }

        static IEnumerable<Type> GetInterfaces(this Type type)
        {
            return type.GetTypeInfo().ImplementedInterfaces.ToArray();
        }

        static IEnumerable<Type> WhereNormalConcrete(this IEnumerable<Type> types)
        {
            return types.WhereNonAbstract().WhereNonGeneric().WhereConcrete();
        }

        static IEnumerable<Type> WhereNonAbstract(this IEnumerable<Type> types)
        {
            return types.Where(t => !t.GetTypeInfo().IsAbstract);
        }

        static IEnumerable<Type> WhereConcrete(this IEnumerable<Type> types)
        {
            return types.Where(t => !t.GetTypeInfo().IsInterface && t.GetTypeInfo().IsClass);
        }

        static IEnumerable<Type> WhereNonGeneric(this IEnumerable<Type> types)
        {
            return types.Where(t => !t.GetTypeInfo().ContainsGenericParameters);
        }
    }
}