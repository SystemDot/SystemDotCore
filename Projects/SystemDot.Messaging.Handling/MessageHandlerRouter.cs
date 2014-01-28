using System;
using SystemDot.Core;
using SystemDot.Ioc;

namespace SystemDot.Messaging.Handling
{
    public class MessageHandlerRouter
    {
        readonly HandlerInstanceList handlersByInstance;
        readonly HandlerTypeList handlersByType;
        readonly HandlerActionList handlersByAction;

        public MessageHandlerRouter()
        {
            handlersByInstance = new HandlerInstanceList();
            handlersByType = new HandlerTypeList();
            handlersByAction = new HandlerActionList();
        }

        public void RegisterHandlersFromContainer<TMessageHandler>(IIocContainer container)
        {
            container
                .GetAllRegisteredTypes()
                .WhereImplements<TMessageHandler>()
                .ForEach(type => RegisterHandler(type, container));
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

        public void RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            handlersByAction.RegisterHandler(toRegister);
        }

        public void UnregisterHandler<TMessage>(Action<TMessage> toUnregister)
        {
            handlersByAction.UnregisterHandler(toUnregister);
        }

        public void RouteMessageToHandlers(object message)
        {
            handlersByInstance.RouteMessageToHandlers(message); 
            handlersByType.RouteMessageToHandlers(message);
            handlersByAction.RouteMessageToHandlers(message);
        }
    }
}
