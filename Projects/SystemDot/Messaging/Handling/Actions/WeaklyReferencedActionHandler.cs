using System;
using SystemDot.Core;

namespace SystemDot.Messaging.Handling.Actions
{
    internal class WeaklyReferencedActionHandler<T> : WeakReference
    {
        public WeaklyReferencedActionHandler(ActionSubscriptionToken<T> token) 
            : base(token)
        {
        }

        public void Handle(T message)
        {
            if (IsAlive) Target.As<ActionSubscriptionToken<T>>().Handle(message);
        }
    }
}