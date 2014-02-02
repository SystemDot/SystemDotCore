using System;
using SystemDot.Core.Collections;

namespace SystemDot.Messaging.Handling.Actions
{
    internal class ActionHandlerList
    {
        readonly TypeKeyConcurrentDictionary<IPerMessageActionHandlerList> handlers;

        public ActionHandlerList()
        {
            handlers = new TypeKeyConcurrentDictionary<IPerMessageActionHandlerList>();
        }

        public bool ContainsHandler<TMessage>()
        {
            return handlers.ContainsKey<TMessage>();
        }

        public void RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            if (!ContainsHandler<TMessage>())
                AddPerMessageList<TMessage>();

            handlers.ExecuteIfExists<TMessage>(list => list.ForMessage<TMessage>().RegisterHandler(toRegister));
        }

        void AddPerMessageList<TMessage>()
        {
            handlers.TryAdd<TMessage>(new PerMessageActionHandlerList<TMessage>());
        }

        public void UnregisterHandler<TMessage>(Action<TMessage> toUnregister)
        {
            if (!ContainsHandler<TMessage>()) return;
            handlers.ExecuteIfExists<TMessage>(list => list.ForMessage<TMessage>().UnregisterHandler(toUnregister));
        }

        public void RouteMessageToHandlers(object message)
        {
            handlers.ExecuteIfExists(message.GetType(), value => value.RouteMessageToHandlers(message));
        }

        public void Clear()
        {
            handlers.Clear();
        }
    }
}