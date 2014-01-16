using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.EventSourcing.Sessions;
using EventStore;

namespace SystemDot.EventSourcing.Sql.Windows
{
    public class EventStoreEventSession : Disposable, IEventSession
    {
        readonly IStoreEvents eventStore;
        readonly Dictionary<Guid, IEventStream> streams;

        public EventStoreEventSession(IStoreEvents eventStore)
        {
            this.eventStore = eventStore;
            streams = new Dictionary<Guid, IEventStream>();
        }

        public IEnumerable<object> AllEvents()
        {
            return eventStore
                .Advanced
                .GetFrom(DateTime.MinValue)
                .SelectMany(e => e.Events)
                .Select(e => e.Body);
        }

        public IEnumerable<object> GetEvents(Guid aggregateRootId)
        {
            IEventStream stream = GetStream(aggregateRootId);

            return stream.CommittedEvents.Select(m => m.Body)
                .Concat(stream.UncommittedEvents.Select(m => m.Body));
        }

        public void StoreEvent(object @event, Guid aggregateRootId, Type aggregateRootType)
        {
            var uncommittedEvent = new EventMessage {Body = @event};
            uncommittedEvent.Headers.Add(EventHeaderKeys.AggregateType, aggregateRootType.FullName);

            GetStream(aggregateRootId).Add(uncommittedEvent);
        }

        public void Commit(Guid commandId)
        {
            streams.ForEach(s => CommitStream(commandId, s.Value));
        }

        IEventStream GetStream(Guid aggregateRootId)
        {
            IEventStream stream;

            if (!streams.TryGetValue(aggregateRootId, out stream)) streams[aggregateRootId] = stream = eventStore.OpenStream(aggregateRootId, 0, int.MaxValue);

            return stream;
        }

        void CommitStream(Guid commandId, IEventStream toCommit)
        {
            try
            {
                toCommit.CommitChanges(commandId);
            }
            catch (DuplicateCommitException)
            {
                toCommit.ClearChanges();
            }
            catch (ConcurrencyException)
            {
                toCommit.ClearChanges();
                throw;
            }
        }

        protected override void DisposeOfManagedResources()
        {
            streams.ForEach(s => s.Value.Dispose());
            streams.Clear();

            base.DisposeOfManagedResources();
        }
    }
}