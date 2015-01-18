using System;
using System.Threading.Tasks;
using SystemDot.Core;

namespace SystemDot.Messaging.Handling.Actions.Async
{
    public class AsyncActionHandlerSubscriptionToken<TMessage> : Disposable, IActionSubscriptionToken
    {
        Func<TMessage, Task> handler;

        public AsyncActionHandlerSubscriptionToken(Func<TMessage, Task> handler)
        {
            this.handler = handler;
        }

        protected override void DisposeOfManagedResources()
        {
            handler = null;
            base.DisposeOfManagedResources();
        }

        public async Task Handle(TMessage message)
        {
            await handler.Invoke(message);
        }
    }
}