using SystemDot.Ioc;

namespace SystemDot.EventSourcing.InMemory.Configuration
{
    internal static class IocContainerExtensions
    {
        internal static void RegisterInMemoryEventSourcing(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<InMemoryEventSession>();
        }
    }
}
