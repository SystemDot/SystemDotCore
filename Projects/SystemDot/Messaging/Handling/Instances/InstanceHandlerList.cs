using System.Collections.Generic;
using System.Threading.Tasks;
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
            if(inner.Contains(handlerInstance)) return;
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

        public async Task RouteMessageToHandlersAsync(object message)
        {
            foreach (var handler in inner)
            {
                await handler.InvokeHandlerAsync(message);
            }
        }

        public void Clear()
        {
            inner.Clear();
        }
    }
}