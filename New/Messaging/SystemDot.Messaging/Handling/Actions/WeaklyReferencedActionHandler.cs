using System;
using SystemDot.Core;
 
namespace SystemDot.Messaging.Handling.Actions
{
    internal class WeaklyReferencedActionHandler : WeakReference
    {
        public object GroupingId { get; private set; }

        public WeaklyReferencedActionHandler(object target, object groupingId) : base(target)
        {
            GroupingId = groupingId;
        }

        public void Handle<T>(T message)
        {
            if (IsAlive) Target.As<ActionHandlerSubscriptionToken<T>>().Handle(message);
        }
    }
}