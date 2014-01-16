using SystemDot.Ioc;

namespace SystemDot.Domain.Configuration
{
    public static class IocContainerExtensions
    {
        internal static void RegisterDomain(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<IDomainRepository>();
        }
    }
}