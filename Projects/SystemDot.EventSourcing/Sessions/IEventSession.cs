using System;
using System.Collections.Generic;

namespace SystemDot.EventSourcing.Sessions
{
    public interface IEventSession : IDisposable
    {
        IEnumerable<object> GetEvents(Guid aggregateRootId);

        void StoreEvent(object @event, Guid aggregateRootId, Type aggregateRootType);

        void Commit(Guid commandId);

        IEnumerable<object> AllEvents();
    }
}