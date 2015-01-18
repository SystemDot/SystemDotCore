using System;
using System.Threading.Tasks;
using SystemDot.Core;
using SystemDot.Messaging.Handling;
using SystemDot.Messaging.Handling.Actions;
using SystemDot.Messaging.Handling.Actions.Async;

namespace SystemDot.Messaging.Simple
{
    public class Dispatcher
    {
        readonly MessageHandlerRouter router;

        public Dispatcher()
        {
            router = new MessageHandlerRouter();
        }

        public void RegisterHandler(object handlerInstance)
        {
            router.RegisterHandler(handlerInstance);
        }

        public void UnregisterHandler(object toUnregister)
        {
            router.UnregisterHandler(toUnregister);
        }

        public ActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            return router.RegisterHandler(toRegister);
        }
        
        public AsyncActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage>(Func<TMessage, Task> toRegister)
        {
            return router.RegisterHandler(toRegister);
        }

        public ActionHandlerSubscriptionToken<TMessage> RegisterHandler<TMessage, TGroupingId>(Action<TMessage> toRegister, TGroupingId groupingId)
        {
            return router.RegisterHandler(toRegister, groupingId);
        }
        
        public void UnregisterHandler<TMessage>(ActionHandlerSubscriptionToken<TMessage> toUnregister)
        {
            router.UnregisterHandler(toUnregister);
        }

        public void Send<TMessage>(TMessage message)
        {
            router.RouteMessageToHandlers(message);
        }

        public TReply SendAndReceiveReply<TRequest, TReply>(TRequest request)
        {
            return router.RouteMessageToOnlyHandler(request).As<TReply>();
        }

        public async Task SendAsync<TMessage>(TMessage message)
        {
            await router.RouteMessageToHandlersAsync(message);
        }

        public async Task<TReply> Send<TRequest, TReply>(TRequest request)
        {
            TReply reply = default(TReply);
            await SendAsync<TRequest, TReply>(request, r => reply = r);
            return reply;
        }

        public void Send<TMessage, TGroupingId>(TMessage message, TGroupingId groupingId)
        {
            router.RouteMessageToHandlers(message, groupingId);
        }

        public void Send<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            using (new ReplyContext<TResponse>(responseHandler))
            {
                router.RouteMessageToHandlers(request);
            }
        }

        public async Task SendAsync<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            using (new ReplyContext<TResponse>(responseHandler))
            {
                await router.RouteMessageToHandlersAsync(request);
            }
        }

        public void Reply<TResponse>(TResponse response)
        {
            ReplyContext<TResponse>.CallCurrentResponseHandler(response);
        }

        public void Reset()
        {
            router.ClearAllHandlers();
        }
    }
}