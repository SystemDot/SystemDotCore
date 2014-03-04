using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.Core.Collections;
using SystemDot.Ioc;

namespace SystemDot.Messaging.Handling.Types
{
    class TypeHandlerList
    {
        readonly List<HandlerType> inner;

        public TypeHandlerList()
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
                .ForEach(type => type.Resolver.Resolve(type.Type).InvokeHandler(message));
        }

        bool HandlesMessageType(Type type, object message)
        {
            return type.GetHandleMethodForMessage(message) != null;
        }

        public void Clear()
        {
            inner.Clear();
        }
    }
}