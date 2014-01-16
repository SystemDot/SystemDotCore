using SystemDot.Core;
using SystemDot.EventSourcing;
using SystemDot.Ioc;
using SystemDot.Messaging.Simple;
using SystemDot.Querying.Mapping;

namespace SystemDot.Querying
{
    public class ReadModelBuilder
    {
        readonly MessageHandlerRouter eventRouter;
        readonly IIocContainer container;
        readonly EventRetreiver eventRetreiver;

        public ReadModelBuilder(IIocContainer container, EventRetreiver eventRetreiver)
        {
            this.container = container;
            this.eventRetreiver = eventRetreiver;

            eventRouter = new MessageHandlerRouter();
        }

        public void Build()
        {
            PopulateRouter();
            eventRetreiver.GetAllEvents().ForEach(BuildFromEvent);
        }

        void BuildFromEvent(object @event)
        {
            eventRouter.RouteMessageToHandlers(@event);
        }

        void PopulateRouter()
        {
            eventRouter.RegisterHandlersFromContainer<IReadModelMapper>(container);
        }
    }
}