using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;

namespace SystemDot.Ioc
{
    public static class IocContainerExtensions
    {
        public static void RegisterFromAssemblyOf<TAssemblyOf>(this IIocContainer container)
        {
            new AutoRegistrar(container)
                .Register(typeof(TAssemblyOf)
                    .GetTypesInAssembly().WhereNormalConcrete());
        }

        public static IEnumerable<T> ResolveAllTypesThatImplement<T>(this IIocContainer resolver)
        {
            return resolver.GetAllRegisteredTypes()
                .ThatImplement<T>()
                .Select(t => resolver.Resolve(t).As<T>());
        }
    }
}