namespace SystemDot.Domain.Aggregation
{
    public abstract class AggregateEntity<TRoot> where TRoot : AggregateRoot
    {
        readonly ConventionEventToHandlerRouter eventRouter;

        public TRoot Root { get; private set; }

        protected AggregateEntity(TRoot root)
        {
            Root = root;
            Root.EventReplayed += OnAggregateRootEventAdded;
            this.eventRouter = new ConventionEventToHandlerRouter(this, "ApplyEvent");
        }

        protected void AddEvent(object @event)
        {
            Root.AddEvent(@event);
        }

        void OnAggregateRootEventAdded(object sender, EventSourceEventArgs e)
        {
            this.eventRouter.RouteEventToHandlers(e.Event);
        }
    }
}