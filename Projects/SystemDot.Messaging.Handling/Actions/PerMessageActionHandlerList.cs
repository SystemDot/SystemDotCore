using System;
using System.Collections.Concurrent;
using System.Linq;
using SystemDot.Core;
using SystemDot.Core.Collections;

namespace SystemDot.Messaging.Handling.Actions
{
    internal class PerMessageActionHandlerList<TMessage> : IPerMessageActionHandlerList
    {
        readonly ConcurrentDictionary<Action<TMessage>, WeaklyReferencedActionHandler<TMessage>> handlers;

        public PerMessageActionHandlerList()
        {
            handlers = new ConcurrentDictionary<Action<TMessage>, WeaklyReferencedActionHandler<TMessage>>();
        }

        public void RouteMessageToHandlers(object message)
        {
            RemoveGarbageCollectedHandlers();
            handlers.ForEach(h => h.Value.Handle(message.As<TMessage>()));
        }

        public PerMessageActionHandlerList<T> ForMessage<T>()
        {
            return this.As<PerMessageActionHandlerList<T>>();
        }

        public void RegisterHandler(Action<TMessage> toRegister)
        {
            RemoveGarbageCollectedHandlers();
            handlers.TryAdd(toRegister, CreateHandler(toRegister));
        }

        static WeaklyReferencedActionHandler<TMessage> CreateHandler(Action<TMessage> toRegister)
        {
            return new WeaklyReferencedActionHandler<TMessage>(toRegister);
        }

        public void UnregisterHandler(Action<TMessage> toUnregister)
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