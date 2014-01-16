using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.Domain.Aggregation;
using SystemDot.EventSourcing.Sessions;

namespace SystemDot.Domain
{
    public class DomainRepository : IDomainRepository
    {
        public bool Exists(Guid aggregateRootId)
        {
            return GetEvents(aggregateRootId).Any();
        }

        static IEnumerable<object> GetEvents(Guid aggregateRootId)
        {
            return EventSessionProvider.Session.GetEvents(aggregateRootId);
        }

        public TAggregateRoot Get<TAggregateRoot>(Guid aggregateRootId)
            where TAggregateRoot : AggregateRoot, new()
        {
            var aggregateRoot = new TAggregateRoot();
            AggregateRoot.SetId(aggregateRoot, aggregateRootId);

            var events = GetEvents(aggregateRootId).ToList();
            if (events.Count == 0)
            {
                throw new AggregateRootDoesNotExistException();
            }

            events.ForEach(aggregateRoot.ReplayEvent);

            return aggregateRoot;
        }
    }
}