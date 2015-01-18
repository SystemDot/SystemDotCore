using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading.Tasks;
using SystemDot.Core;
using SystemDot.Core.Collections;

namespace SystemDot.Messaging.Handling.Actions.Async
{
    internal class AsyncPerMessageActionHandlerList<TMessage> : IAsyncPerMessageActionHandlerList
    {
        readonly ConcurrentDictionary<IActionSubscriptionToken, AsyncWeaklyReferencedActionHandler> handlers;

        public AsyncPerMessageActionHandlerList()
        {
            handlers = new ConcurrentDictionary<IActionSubscriptionToken, AsyncWeaklyReferencedActionHandler>();
        }

        public async Task RouteMessageToHandlers(object message, object groupingId)
        {
            RemoveGarbageCollectedHandlers();
            foreach (var handler in handlers.Where(h => h.Value.GroupingId.Equals(groupingId)))
            {
                 await handler.Value.Handle(message.As<TMessage>());
            }
        }

        public AsyncPerMessageActionHandlerList<T> ForMessage<T>()
        {
            return this.As<AsyncPerMessageActionHandlerList<T>>();
        }

        public AsyncActionHandlerSubscriptionToken<TMessage> RegisterHandler(Func<TMessage, Task> toRegister, object groupingId)
        {
            RemoveGarbageCollectedHandlers();

            var token = new AsyncActionHandlerSubscriptionToken<TMessage>(toRegister);

            handlers.TryAdd(token, CreateHandler(token, groupingId));

            return token;
        }

        static AsyncWeaklyReferencedActionHandler CreateHandler(AsyncActionHandlerSubscriptionToken<TMessage> toRegister, object groupingId)
        {
            return new AsyncWeaklyReferencedActionHandler(toRegister, groupingId);
        }

        public void UnregisterHandler(AsyncActionHandlerSubscriptionToken<TMessage> toUnregister)
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