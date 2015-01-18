using System;
using System.Threading.Tasks;
using SystemDot.Core;

namespace SystemDot.Messaging.Handling.Actions.Async
{
    internal class AsyncWeaklyReferencedActionHandler : WeakReference
    {
        public object GroupingId { get; private set; }

        public AsyncWeaklyReferencedActionHandler(object target, object groupingId)
            : base(target)
        {
            GroupingId = groupingId;
        }

        public async Task Handle<T>(T message)
        {
            if (IsAlive) await Target.As<AsyncActionHandlerSubscriptionToken<T>>().Handle(message);
        }
    }
}