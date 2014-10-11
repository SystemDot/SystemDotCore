using System;
using System.Threading.Tasks;
using SystemDot.Core;
using SystemDot.Messaging.Handling;
using SystemDot.Messaging.Handling.Actions;

namespace SystemDot.Messaging.Simple
{
    public static class Messenger
    {
        static readonly MessageHandlerRouter Router;

        static Messenger()
        {
            Router = new MessageHandlerRouter();
        }

        public static void RegisterHandler(object handlerInstance)
        {
            Router.RegisterHandler(handlerInstance);
        }

        public static void UnregisterHandler(object toUnregister)
        {
            Router.UnregisterHandler(toUnregister);
        }

        public static ActionSubscriptionToken<TMessage> RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            return Router.RegisterHandler(toRegister);
        }

        public static ActionSubscriptionToken<TMessage> RegisterHandler<TMessage, TGroupingId>(Action<TMessage> toRegister, TGroupingId groupingId)
        {
            return Router.RegisterHandler(toRegister, groupingId);
        }

        public static void UnregisterHandler<TMessage>(ActionSubscriptionToken<TMessage> toUnregister)
        {
            Router.UnregisterHandler(toUnregister);
        }

        public static void Send<TMessage>(TMessage message)
        {
            Router.RouteMessageToHandlers(message);
        }

        public static TReply SendAndReceiveReply<TRequest, TReply>(TRequest request)
        {
            return Router.RouteMessageToOnlyHandler(request).As<TReply>();
        }

        public async static Task SendAsync<TMessage>(TMessage message)
        {
            await Router.RouteMessageToHandlersAsync(message);
        }

        public async static Task<TReply> Send<TRequest, TReply>(TRequest request)
        {
            TReply reply = default(TReply);
            await SendAsync<TRequest, TReply>(request, r => reply = r);
            return reply;
        }

        public static void Send<TMessage, TGroupingId>(TMessage message, TGroupingId groupingId)
        {
            Router.RouteMessageToHandlers(message, groupingId);
        }

        public static void Send<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            using (new ReplyContext<TResponse>(responseHandler))
            {
                Router.RouteMessageToHandlers(request);
            }
        }

        public async static Task SendAsync<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            using (new ReplyContext<TResponse>(responseHandler))
            {
                await Router.RouteMessageToHandlersAsync(request);
            }
        }

        public static void Reply<TResponse>(TResponse response)
        {
            ReplyContext<TResponse>.CallCurrentResponseHandler(response);
        }

        public static void Reset()
        {
            Router.ClearAllHandlers();
        }

        
    }
}