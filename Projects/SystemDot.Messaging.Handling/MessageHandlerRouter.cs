using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.Ioc;

namespace SystemDot.Messaging.Handling
{
    public class MessageHandlerRouter
    {
        readonly List<object> handlerInstances;
        readonly List<HandlerType> handlerTypes;

        public MessageHandlerRouter()
        {
            handlerInstances = new List<object>();
            handlerTypes = new List<HandlerType>();
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
            if (handlerTypes.Any(handler => handler.Type == handlerType)) return;
            handlerTypes.Add(new HandlerType(handlerType, container));
        }

        public void RegisterHandler(object handlerInstance)
        {
            handlerInstances.Add(handlerInstance);
        }

        public void UnregisterHandler(object toUnregister)
        {
            handlerInstances.Remove(toUnregister);
        }

        public void RouteMessageToHandlers(object message)
        {
            RouterToRegisteredInstances(message); 
            RouterToRegisteredTypes(message);
        }

        void RouterToRegisteredInstances(object message)
        {
            handlerInstances.ForEach(handler => handler.Invoke(message));
        }

        void RouterToRegisteredTypes(object message)
        {
            handlerTypes
                .Where(handler => HandlesMessageType(handler.Type, message))
                .ForEach(type => type.Resolver.Resolve(type.Type).Invoke(message));
        }

        bool HandlesMessageType(Type type, object message)
        {
            return type.GetHandleMethodForMessage(message) != null;
        }
    }
}
