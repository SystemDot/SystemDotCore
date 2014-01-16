using System.Collections.Generic;
using System.Linq;
using SystemDot.EventSourcing.Sessions;

namespace SystemDot.EventSourcing
{
    public class EventRetreiver
    {
        readonly IEventSessionFactory factory;

        public EventRetreiver(IEventSessionFactory factory)
        {
            this.factory = factory;
        }

        public List<object> GetAllEvents()
        {
            return factory.Create().AllEvents().ToList();
        }
    }
}