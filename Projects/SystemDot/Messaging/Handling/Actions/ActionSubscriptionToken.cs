using System;
using SystemDot.Core;

namespace SystemDot.Messaging.Handling.Actions
{
    public class ActionSubscriptionToken<TMessage> : Disposable, IActionSubscriptionToken
    {
        Action<TMessage> handler;

        public ActionSubscriptionToken(Action<TMessage> handler)
        {
            this.handler = handler;
        }

        protected override void DisposeOfManagedResources()
        {
            handler = null;
            base.DisposeOfManagedResources();
        }

        public void Handle(TMessage message)
        {
            handler.Invoke(message);
        }
    }
}