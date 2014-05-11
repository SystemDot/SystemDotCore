using System;
using SystemDot.Core;
 
namespace SystemDot.Messaging.Handling.Actions
{
    internal class WeaklyReferencedActionHandler : WeakReference
    {
        public WeaklyReferencedActionHandler(object target) : base(target)
        {
        }
 
        public void Handle<T>(T message)
        {
            if (IsAlive) Target.As<ActionSubscriptionToken<T>>().Handle(message);
        }
    }
}