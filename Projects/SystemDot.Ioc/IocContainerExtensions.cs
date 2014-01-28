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
    }
}