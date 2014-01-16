using System;
using SystemDot.EventSourcing.Sessions;

namespace SystemDot.Domain.Aggregation
{
    public abstract class AggregateRoot
    {
        public static EventHandler<EventSourceEventArgs> EventAdded;
        public EventHandler<EventSourceEventArgs> EventReplayed;
        
        readonly ConventionEventToHandlerRouter eventRouter;

        public Guid Id { get; private set; }

        protected AggregateRoot()
        {
            this.eventRouter = new ConventionEventToHandlerRouter(this, "ApplyEvent");
        }

        protected AggregateRoot(Guid id) : this()
        {
            Id = id;
        }

        protected internal void AddEvent(object @event)
        {
            ReplayEvent(@event);

            EventSessionProvider.Session.StoreEvent(@event, Id, GetType());
        }

        public void ReplayEvent(object toReplay)
        {
            this.eventRouter.RouteEventToHandlers(toReplay);

            OnEventReplayed(toReplay);
        }

        void OnEventReplayed(object @event)
        {
            if (EventReplayed != null)
            {
                EventReplayed(this, new EventSourceEventArgs(@event));
            }
        }

        internal static void SetId(AggregateRoot aggregateRoot, Guid id)
        {
            aggregateRoot.Id = id;
        }
    }
}