using System;
using System.Collections.Concurrent;
using SystemDot.Core;

namespace SystemDot.Messaging.Handling
{
    public class HandlerActionList
    {
        readonly ConcurrentDictionary<object, object> handlers;

        public HandlerActionList()
        {
            handlers = new ConcurrentDictionary<object, object>();
        }

        public bool ContainsHandler<TMessage>()
        {
            return handlers.ContainsKey(typeof(TMessage));
        }

        public void RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            if (ContainsHandler<TMessage>()) return;
            handlers.TryAdd(typeof(TMessage), new ActionHandler<TMessage>(toRegister));
        }

        public void UnregisterHandler<TMessage>(Action<TMessage> toUnregister)
        {
            if (!ContainsHandler<TMessage>()) return;
            
            object temp;
            handlers.TryRemove(typeof (TMessage), out temp);
        }

        public void RouteMessageToHandlers(object message)
        {
            handlers.ForEach(h => h.Value.Invoke(message));
        }
    }
}