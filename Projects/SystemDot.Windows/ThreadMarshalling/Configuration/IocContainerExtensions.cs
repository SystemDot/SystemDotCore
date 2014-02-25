using SystemDot.Ioc;

namespace SystemDot.ThreadMarshalling.Configuration
{
    public static class IocContainerExtensions
    {
        public static void RegisterThreadMarshalling(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<MainThreadMarshaller>();
        }
    }
}
