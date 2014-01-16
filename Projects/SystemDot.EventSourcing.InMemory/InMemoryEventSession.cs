using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.EventSourcing.Dispatching;
using SystemDot.EventSourcing.Sessions;

namespace SystemDot.EventSourcing.InMemory
{
    public class InMemoryEventSession : IEventSession
    {
        private readonly IEventDispatcher eventDispatcher;
        private readonly List<EventContainer> events;
        private readonly List<EventContainer> eventsToCommit;

        public InMemoryEventSession(IEventDispatcher eventDispatcher)
        {
            this.eventDispatcher = eventDispatcher;
            events = new List<EventContainer>();
            eventsToCommit = new List<EventContainer>();
        }

        public Guid CommandId { get; private set; }

        public IEnumerable<object> GetEvents(Guid aggregateRootId)
        {
            return events
                .Where(e => e.AggregateRootId == aggregateRootId)
                .Select(e => e.Event);
        }

        public void StoreEvent(object @event, Guid aggregateRootId, Type aggregateRootType)
        {
            var eventContainer = new EventContainer(aggregateRootId, @event);
            events.Add(eventContainer);
            eventsToCommit.Add(eventContainer);
        }

        public void Commit(Guid commandId)
        {
            eventsToCommit
                .Select(e => e.Event)
                .ForEach(eventDispatcher.Dispatch);

            eventsToCommit.Clear();

            CommandId = commandId;
        }

        public void Dispose()
        {
        }

        public IEnumerable<object> AllEvents()
        {
            return events.Select(c => c.Event);
        }

        public TEvent LastEvent<TEvent>() where TEvent : class
        {
            return events.Last() as TEvent;
        }

        public IEnumerable<TEvent> AllEventsOfType<TEvent>()
        {
            return events
                .Select(e => e.Event)
                .OfType<TEvent>();
        }

        private class EventContainer
        {
            public EventContainer(Guid aggregateRootId, object @event)
            {
                AggregateRootId = aggregateRootId;
                Event = @event;
            }

            public Guid AggregateRootId { get; private set; }

            public object Event { get; private set; }
        }
    }
}