using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.Ioc;

namespace SystemDot.Messaging.Handling
{
    class HandlerTypeList
    {
        readonly List<HandlerType> inner;

        public HandlerTypeList()
        {
            inner = new List<HandlerType>();
        }

        public void RegisterHandler(Type handlerType, IIocResolver container)
        {
            if (inner.Any(handler => handler.Type == handlerType)) return;
            inner.Add(new HandlerType(handlerType, container));
        }

        public void RouteMessageToHandlers(object message)
        {
            inner
                .Where(handler => HandlesMessageType(handler.Type, message))
                .ForEach(type => ObjectExtensions.Invoke(type.Resolver.Resolve(type.Type), message));
        }

        bool HandlesMessageType(Type type, object message)
        {
            return type.GetHandleMethodForMessage(message) != null;
        }
    }
}