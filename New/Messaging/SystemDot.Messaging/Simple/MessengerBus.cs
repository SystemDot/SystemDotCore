using System;
using System.Threading.Tasks;
using SystemDot.Messaging.Handling.Actions;

namespace SystemDot.Messaging.Simple
{
    public class MessengerBus : IBus
    {
        public void Publish(object toPublish)
        {
            Messenger.Send(toPublish);
        }

        public async Task PublishAsync(object toPublish)
        {
            await Messenger.SendAsync(toPublish);
        }

        public void Send(object toSend)
        {
            Messenger.Send(toSend);
        }

        public async Task SendAsync(object toSend)
        {
            await Messenger.SendAsync(toSend);
        }

        public void Reply<TReply>(TReply toSend)
        {
            Messenger.Reply(toSend);
        }

        public void Send<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            Messenger.Send(request, responseHandler);
        }

        public async Task SendAsync<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            await Messenger.SendAsync(request, responseHandler);
        }

        public ActionSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            return Messenger.RegisterHandler(toRegister);
        }
    }
}