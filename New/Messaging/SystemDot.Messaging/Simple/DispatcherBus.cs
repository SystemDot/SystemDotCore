using System;
using System.Threading.Tasks;
using SystemDot.Messaging.Handling.Actions;

namespace SystemDot.Messaging.Simple
{
    public class DispatcherBus : IBus
    {
        readonly Dispatcher dispatcher;

        public DispatcherBus(Dispatcher dispatcher)
        {
            this.dispatcher = dispatcher;
        }

        public void Publish(object toPublish)
        {
            dispatcher.Send(toPublish);
        }

        public async Task PublishAsync(object toPublish)
        {
            await dispatcher.SendAsync(toPublish);
        }

        public void Send(object toSend)
        {
            dispatcher.Send(toSend);
        }

        public async Task SendAsync(object toSend)
        {
            await dispatcher.SendAsync(toSend);
        }

        public void Reply<TReply>(TReply toSend)
        {
            dispatcher.Reply(toSend);
        }

        public void Send<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            dispatcher.Send(request, responseHandler);
        }

        public async Task SendAsync<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            await dispatcher.SendAsync(request, responseHandler);
        }

        public ActionSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            return dispatcher.RegisterHandler(toRegister);
        }
    }
}