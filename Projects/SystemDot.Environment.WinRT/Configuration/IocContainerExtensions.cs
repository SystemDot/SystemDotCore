using SystemDot.Ioc;

namespace SystemDot.Environment.Configuration
{
    public static class IocContainerExtensions
    {
        public static void RegisterFileSystem(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<Application>();
        }
    }
}