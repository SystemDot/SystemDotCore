using System;
using System.Collections.Generic;
using SystemDot.Core;
using SystemDot.Core.Collections;
using SystemDot.Ioc.Multiples;

namespace SystemDot.Ioc
{
    public static class IocContainerExtensions
    {
        public static MultipleTypesRegistration RegisterMultipleTypes(this IIocContainer container)
        {
            return new MultipleTypesRegistration(container);
        }

        [Obsolete]
        public static void RegisterFromAssemblyOf<TAssemblyOf>(this IIocContainer container)
        {
            container
                .RegisterMultipleTypes()
                .FromAssemblyOf<TAssemblyOf>()
                .AllTypes()
                .ByClassAndInterface();
        }

        [Obsolete]
        public static IEnumerable<T> ResolveAllTypesThatImplement<T>(this IIocContainer resolver)
        {
            return resolver.ResolveMutipleTypes().ThatImplement<T>();
        }

        public static MutlipleTypeResolver ResolveMutipleTypes(this IIocContainer resolver)
        {
            return new MutlipleTypeResolver(resolver);
        }

        public static void RegisterOpenTypeDecorators(this IIocContainer container, Type openType, Type openDecoratorType)
        {
            container.GetAllRegisteredTypes()
                .WhereImplementsOpenType(openType)
                .ForEach(t => container.RegisterOpenTypeDecorator(t, openDecoratorType));
        }
    }
}