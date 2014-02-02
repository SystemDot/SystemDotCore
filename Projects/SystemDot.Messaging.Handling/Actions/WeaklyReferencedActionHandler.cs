using System;
using SystemDot.Core;

namespace SystemDot.Messaging.Handling.Actions
{
    internal class WeaklyReferencedActionHandler<T> : WeakReference
    {
        public WeaklyReferencedActionHandler(Action<T> action) 
            : base(new ActionHandler<T>(action))
        {
        }

        public void Handle(T message)
        {
            if(IsAlive) Target.As<ActionHandler<T>>().Handle(message);
        }
    }
}