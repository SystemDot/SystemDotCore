using System.Collections.Generic;
using SystemDot.Core;
using SystemDot.Core.Collections;

namespace SystemDot.Messaging.Handling.Instances
{
    class InstanceHandlerList
    {
        readonly List<object> inner;

        public InstanceHandlerList()
        {
            inner = new List<object>();
        }

        public void RegisterHandler(object handlerInstance)
        {
            inner.Add(handlerInstance);
        }

        public void Unregister(object toUnregister)
        {
            inner.Remove(toUnregister);
        }

        public void RouteMessageToHandlers(object message)
        {
            inner.ForEach(handler => handler.InvokeHandler(message));
        }
    }
}