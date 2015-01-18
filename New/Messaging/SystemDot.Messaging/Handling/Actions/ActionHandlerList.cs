using System;

namespace SystemDot.Messaging.Handling.Actions
{
    internal class ActionHandlerList
    {
        readonly TypeKeyConcurrentDictionary<IPerMessageActionHandlerList> handlers;

        public ActionHandlerList()
        {
            handlers = new TypeKeyConcurrentDictionary<IPerMessageActionHandlerList>();
        }

        bool ContainsHandler<TMessage>()
        {
            return handlers.ContainsKey<TMessage>();
        }

        public ActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister, object groupingId)
        {
            if (!ContainsHandler<TMessage>()) AddPerMessageList<TMessage>();

            ActionHandlerSubscriptionToken<TMessage> token = null;

            handlers.ExecuteIfExists<TMessage>(list =>
            {
               token = list.ForMessage<TMessage>().RegisterHandler(toRegister, groupingId); 
            });

            return token;
        }

        void AddPerMessageList<TMessage>()
        {
            handlers.TryAdd<TMessage>(new PerMessageActionHandlerList<TMessage>());
        }

        public void UnregisterHandler<TMessage>(ActionHandlerSubscriptionToken<TMessage> toUnregister)
        {
            if (!ContainsHandler<TMessage>()) return;
            handlers.ExecuteIfExists<TMessage>(list => list.ForMessage<TMessage>().UnregisterHandler(toUnregister));
        }

        public void RouteMessageToHandlers(object message, object groupingId)
        {
            handlers.ExecuteIfExists(message.GetType(), value => value.RouteMessageToHandlers(message, groupingId));
        }

        public void Clear()
        {
            handlers.Clear();
        }
    }
}