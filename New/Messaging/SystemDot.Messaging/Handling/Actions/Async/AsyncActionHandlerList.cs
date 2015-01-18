using System;
using System.Threading.Tasks;

namespace SystemDot.Messaging.Handling.Actions.Async
{
    internal class AsyncActionHandlerList
    {
        readonly TypeKeyConcurrentDictionary<IAsyncPerMessageActionHandlerList> handlers;

        public AsyncActionHandlerList()
        {
            handlers = new TypeKeyConcurrentDictionary<IAsyncPerMessageActionHandlerList>();
        }

        bool ContainsHandler<TMessage>()
        {
            return handlers.ContainsKey<TMessage>();
        }

        public AsyncActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage>(Func<TMessage, Task> toRegister, object groupingId)
        {
            if (!ContainsHandler<TMessage>()) AddPerMessageList<TMessage>();

            AsyncActionHandlerSubscriptionToken<TMessage> token = null;

            handlers.ExecuteIfExists<TMessage>(list =>
            {
                token = list.ForMessage<TMessage>().RegisterHandler(toRegister, groupingId);
            });

            return token;
        }

        void AddPerMessageList<TMessage>()
        {
            handlers.TryAdd<TMessage>(new AsyncPerMessageActionHandlerList<TMessage>());
        }

        public void UnregisterHandler<TMessage>(AsyncActionHandlerSubscriptionToken<TMessage> toUnregister)
        {
            if (!ContainsHandler<TMessage>()) return;
            handlers.ExecuteIfExists<TMessage>(list => list.ForMessage<TMessage>().UnregisterHandler(toUnregister));
        }

        public async Task RouteMessageToHandlers(object message, object groupingId)
        {
            await handlers.ExecuteIfExistsAsync(message.GetType(), value => value.RouteMessageToHandlers(message, groupingId));
        }

        public void Clear()
        {
            handlers.Clear();
        }
    }
}