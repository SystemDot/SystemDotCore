using SystemDot.Configuration;
using SystemDot.EventSourcing.Configuration;
using SystemDot.EventSourcing.Dispatching;
using SystemDot.Ioc;
using EventStore;

namespace SystemDot.EventSourcing.Sql.Windows.Configuration
{
    public static class EventSourcingBuilderConfigurationExtensions
    {
        public static IBuilderConfiguration PersistToSql(this EventSourcingBuilderConfiguration config, string connectionString)
        {
            config.GetBuilderConfiguration().RegisterBuildAction(c => c.RegisterSqlWindowsEventSourcing());
            config.GetBuilderConfiguration().RegisterBuildAction(c => Build(c, connectionString));
            return config.GetBuilderConfiguration();
        }

        static void Build(IIocContainer container, string connectionString)
        {
            container.RegisterInstance<IStoreEvents>(() =>
                Wireup.Init()
                    .UsingSqlPersistence(connectionString)
                    .InitializeStorageEngine()
                    .UsingJsonSerialization()
                    .UsingSynchronousDispatchScheduler()
                    .DispatchTo(new MessageBusCommitDispatcher(container.Resolve<IEventDispatcher>()))
                    .Build());
        }
    }
}