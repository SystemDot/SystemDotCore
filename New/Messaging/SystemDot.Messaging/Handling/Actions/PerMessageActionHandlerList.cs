using System;
using System.Collections.Concurrent;
using System.Linq;
using SystemDot.Core;
using SystemDot.Core.Collections;

namespace SystemDot.Messaging.Handling.Actions
{
    internal class PerMessageActionHandlerList<TMessage> : IPerMessageActionHandlerList
    {
        readonly ConcurrentDictionary<IActionSubscriptionToken, WeaklyReferencedActionHandler> handlers;

        public PerMessageActionHandlerList()
        {
            handlers = new ConcurrentDictionary<IActionSubscriptionToken, WeaklyReferencedActionHandler>();
        }

        public void RouteMessageToHandlers(object message, object groupingId)
        {
            RemoveGarbageCollectedHandlers();
            handlers
                .Where(h => h.Value.GroupingId.Equals(groupingId))
                .ForEach(h => h.Value.Handle(message.As<TMessage>()));
        }

        public PerMessageActionHandlerList<T> ForMessage<T>()
        {
            return this.As<PerMessageActionHandlerList<T>>();
        }

        public ActionSubscriptionToken<TMessage> RegisterHandler(Action<TMessage> toRegister, object groupingId)
        {
            RemoveGarbageCollectedHandlers();

            var token = new ActionSubscriptionToken<TMessage>(toRegister);

            handlers.TryAdd(token, CreateHandler(token, groupingId));

            return token;
        }

        static WeaklyReferencedActionHandler CreateHandler(ActionSubscriptionToken<TMessage> toRegister, object groupingId)
        {
            return new WeaklyReferencedActionHandler(toRegister, groupingId);
        }

        public void UnregisterHandler(ActionSubscriptionToken<TMessage> toUnregister)
        {
            RemoveGarbageCollectedHandlers();
            handlers.TryRemove(toUnregister);
        }

        void RemoveGarbageCollectedHandlers()
        {
            handlers
                .Where(h => !h.Value.IsAlive)
                .ToList()
                .ForEach(h => handlers.TryRemove(h.Key));
        }
    }
}