using System;
using System.Threading.Tasks;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Messaging.Handling.Actions.Async;
using SystemDot.Messaging.Handling.Instances;

namespace SystemDot.Messaging.Handling
{
    public class MessageHandlerRouter
    {
        readonly InstanceHandlerList handlersByInstance;
        readonly ActionHandlerList handlersByAction;
        readonly AsyncActionHandlerList handlersByAsyncAction;

        public MessageHandlerRouter()
        {
            handlersByInstance = new InstanceHandlerList();
            handlersByAction = new ActionHandlerList();
            handlersByAsyncAction = new AsyncActionHandlerList();
        }

        public void RegisterHandler(object handlerInstance)
        {
            handlersByInstance.RegisterHandler(handlerInstance);
        }

        public void UnregisterHandler(object toUnregister)
        {
            handlersByInstance.Unregister(toUnregister);
        }

        public ActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            return RegisterHandler(toRegister, GlobalGroupingId.Default);
        }
        
        public AsyncActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage>(Func<TMessage, Task> toRegister)
        {
            return RegisterHandler(toRegister, GlobalGroupingId.Default);
        }

        public ActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage, TGroupingId>(Action<TMessage> toRegister, TGroupingId groupingId)
        {
            return handlersByAction.RegisterHandler(toRegister, groupingId);
        }

        AsyncActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage, TGroupingId>(Func<TMessage, Task> toRegister, TGroupingId groupingId)
        {
            return handlersByAsyncAction.RegisterHandler(toRegister, groupingId);
        }

        public void UnregisterHandler<TMessage>(ActionHandlerSubscriptionToken<TMessage> toUnregister)
        {
            handlersByAction.UnregisterHandler(toUnregister);
        }

        public void UnregisterHandler<TMessage>(AsyncActionHandlerSubscriptionToken<TMessage> toUnregister)
        {
            handlersByAsyncAction.UnregisterHandler(toUnregister);
        }

        public void RouteMessageToHandlers(object message)
        {
            RouteMessageToHandlers(message, GlobalGroupingId.Default);
        }

        public object RouteMessageToOnlyHandler(object message)
        {
            return handlersByInstance.RouteMessageToOnlyHandler(message); 
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
            await handlersByAsyncAction.RouteMessageToHandlers(message, groupingId);
            handlersByAction.RouteMessageToHandlers(message, groupingId);
        }

        public void ClearAllHandlers()
        {
            handlersByInstance.Clear();
            handlersByAction.Clear();
            handlersByAsyncAction.Clear();
        }
    }
}
