using System;
using SystemDot.Messaging.Handling.Actions;

namespace SystemDot.Messaging.Simple
{
    public class MessengerBus : IBus
    {
        public void Publish(object toPublish)
        {
            Messenger.Send(toPublish);
        }

        public void Send(object toSend)
        {
            Messenger.Send(toSend);
        }

        public void Reply<TReply>(TReply toSend)
        {
            Messenger.Reply(toSend);
        }

        public void Send<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            Messenger.Send(request, responseHandler);
        }

        public ActionSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            return Messenger.RegisterHandler(toRegister);
        }
    }
}