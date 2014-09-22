using System;
using System.Threading.Tasks;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Messaging.Handling.Instances;

namespace SystemDot.Messaging.Handling
{
    public class MessageHandlerRouter
    {
        readonly InstanceHandlerList handlersByInstance;
        readonly ActionHandlerList handlersByAction;

        public MessageHandlerRouter()
        {
            handlersByInstance = new InstanceHandlerList();
            handlersByAction = new ActionHandlerList();
        }

        public void RegisterHandler(object handlerInstance)
        {
            handlersByInstance.RegisterHandler(handlerInstance);
        }

        public void UnregisterHandler(object toUnregister)
        {
            handlersByInstance.Unregister(toUnregister);
        }

        public ActionSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            return RegisterHandler(toRegister, GlobalGroupingId.Default);
        }

        public ActionSubscriptionToken<TMessage> RegisterHandler<TMessage, TGroupingId>(Action<TMessage> toRegister, TGroupingId groupingId)
        {
            return handlersByAction.RegisterHandler(toRegister, groupingId);
        }

        public void UnregisterHandler<TMessage>(ActionSubscriptionToken<TMessage> toUnregister)
        {
            handlersByAction.UnregisterHandler(toUnregister);
        }

        public void RouteMessageToHandlers(object message)
        {
            RouteMessageToHandlers(message, GlobalGroupingId.Default);
        }

        public async Task RouteMessageToHandlersAsync(object message)
        {
            await RouteMessageToHandlersAsync(message, GlobalGroupingId.Default);
        }

        public void RouteMessageToHandlers(object message, object groupingId)
        {
            handlersByInstance.RouteMessageToHandlers(message); 
            handlersByAction.RouteMessageToHandlers(message, groupingId);
        }

        async Task RouteMessageToHandlersAsync(object message, object groupingId)
        {
            await handlersByInstance.RouteMessageToHandlersAsync(message);
            handlersByAction.RouteMessageToHandlers(message, groupingId);
        }

        public void ClearAllHandlers()
        {
            handlersByInstance.Clear();
            handlersByAction.Clear();
        }
    }
}
