using System.Collections.Generic;
using SystemDot.Core;

namespace SystemDot.Messaging.Handling
{
    class HandlerInstanceList
    {
        readonly List<object> inner;

        public HandlerInstanceList()
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
            inner.ForEach(handler => handler.Invoke(message));
        }
    }
}