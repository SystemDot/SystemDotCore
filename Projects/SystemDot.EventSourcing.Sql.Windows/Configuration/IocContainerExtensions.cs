using SystemDot.Ioc;

namespace SystemDot.EventSourcing.Sql.Windows.Configuration
{
    public static class IocContainerExtensions
    {
        internal static void RegisterSqlWindowsEventSourcing(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<EventStoreEventSession>();
        }
    }
}
