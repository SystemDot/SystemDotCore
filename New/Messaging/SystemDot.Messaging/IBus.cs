using System;
using System.Threading.Tasks;
using SystemDot.Messaging.Handling.Actions;

namespace SystemDot.Messaging
{
    public interface IBus
    {
        void Publish(object toPublish);
        Task PublishAsync(object toPublish);
        void Send(object toSend);
        Task SendAsync(object toSend);
        void Reply<TReply>(TReply toSend);
        void Send<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler);
        Task SendAsync<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler);
        ActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister);
    }
}