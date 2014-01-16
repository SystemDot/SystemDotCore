using SystemDot.EventSourcing.Sessions;
using SystemDot.Ioc;

namespace SystemDot.EventSourcing.Configuration
{
    public static class IocContainerExtensions
    {
        internal static void RegisterEventSourcing(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<IEventSession>();
        }
    }
}
