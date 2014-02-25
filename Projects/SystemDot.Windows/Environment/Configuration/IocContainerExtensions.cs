using SystemDot.Ioc;

namespace SystemDot.Environment.Configuration
{
    public static class IocContainerExtensions
    {
        public static void RegisterEnvironment(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<Application>();
        }
    }
}