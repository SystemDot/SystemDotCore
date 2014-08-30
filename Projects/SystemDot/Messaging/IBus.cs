using System;
using SystemDot.Messaging.Handling.Actions;

namespace SystemDot.Messaging
{
    public interface IBus
    {
        void Publish(object toPublish);
        void Send(object toSend);
        void Reply<TReply>(TReply toSend);
        void Send<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler);
        ActionSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister);
    }
}