using SystemDot.Ioc;

namespace Domain.Configuration
{
    internal static class IocContainerExtensions
    {
        public static void RegisterTestDomain(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<ActivateVendor>();
        }
    }
}