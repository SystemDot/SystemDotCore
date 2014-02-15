using System;
using SystemDot.Core;
using SystemDot.Core.Collections;
using SystemDot.Ioc;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Messaging.Handling.Instances;
using SystemDot.Messaging.Handling.Types;

namespace SystemDot.Messaging.Handling
{
    public class MessageHandlerRouter
    {
        readonly InstanceHandlerList handlersByInstance;
        readonly TypeHandlerList handlersByType;
        readonly ActionHandlerList handlersByAction;

        public MessageHandlerRouter()
        {
            handlersByInstance = new InstanceHandlerList();
            handlersByType = new TypeHandlerList();
            handlersByAction = new ActionHandlerList();
        }

        public void RegisterHandlersFromContainer<TMessageHandler>(IIocResolver resolver)
        {
            resolver
                .GetAllRegisteredTypes()
                .WhereImplements<TMessageHandler>()
                .ForEach(type => RegisterHandler(type, resolver));
        }

        void RegisterHandler(Type handlerType, IIocResolver container)
        {
            handlersByType.RegisterHandler(handlerType, container);
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
            return handlersByAction.RegisterHandler(toRegister);
        }

        public void UnregisterHandler<TMessage>(ActionSubscriptionToken<TMessage> toUnregister)
        {
            handlersByAction.UnregisterHandler(toUnregister);
        }

        public void RouteMessageToHandlers(object message)
        {
            handlersByInstance.RouteMessageToHandlers(message); 
            handlersByType.RouteMessageToHandlers(message);
            handlersByAction.RouteMessageToHandlers(message);
        }

        public void ClearAllHandlers()
        {
            handlersByAction.Clear();
        }
    }
}
