using System;

namespace SystemDot.Messaging.Handling
{
    public class ActionHandler<T> : IMessageHandler<T>
    {
        readonly Action<T> action;

        public ActionHandler(Action<T> action)
        {
            this.action = action;
        }

        public void Handle(T message)
        {
            action(message);
        }
    }
}