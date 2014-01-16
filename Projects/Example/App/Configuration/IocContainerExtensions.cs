using SystemDot.Ioc;
using Domain;

namespace App.Configuration
{
    internal static class IocContainerExtensions
    {
        public static void RegisterTestApp(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<VendorListItem>();
        }
    }
}