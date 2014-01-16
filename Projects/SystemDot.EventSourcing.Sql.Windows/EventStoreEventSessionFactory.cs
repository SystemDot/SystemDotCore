using SystemDot.EventSourcing.Sessions;
using EventStore;

namespace SystemDot.EventSourcing.Sql.Windows
{
    public class EventStoreEventSessionFactory : IEventSessionFactory
    {
        readonly IStoreEvents eventStore;

        public EventStoreEventSessionFactory(IStoreEvents eventStore)
        {
            this.eventStore = eventStore;
        }

        public IEventSession Create()
        {
            var session = new EventStoreEventSession(eventStore);
            EventSessionProvider.Session = session;

            return session;
        }
    }
}