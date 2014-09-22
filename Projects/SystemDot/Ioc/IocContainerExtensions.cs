using System;
using System.Collections.Generic;
using SystemDot.Ioc.Multiples;

namespace SystemDot.Ioc
{
    public static class IocContainerExtensions
    {
        public static MultipleTypesRegistration RegisterMultipleTypes(this IIocContainer container)
        {
            return new MultipleTypesRegistration(container);
        }

        public static MutlipleTypeResolver ResolveMutipleTypes(this IIocContainer resolver)
        {
            return new MutlipleTypeResolver(resolver);
        }

        public static MultipleDecoratorRegistration DecorateMultipleTypes(this IIocContainer container)
        {
            return new MultipleDecoratorRegistration(container);
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
        public static IEnumerable<T> ResolveAllTypesThatImplement<T>(this IocContainer resolver)
        {
            return resolver.ResolveMutipleTypes().ThatImplement<T>();
        }
    }
}