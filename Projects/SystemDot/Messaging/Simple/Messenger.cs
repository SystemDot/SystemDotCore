using System;
using SystemDot.Ioc;
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

        public static void RegisterHandlersFromContainer<TMessageHandler>(IIocContainer container)
        {
            Router.RegisterHandlersFromContainer<TMessageHandler>(container);
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

        public static void UnregisterHandler<TMessage>(ActionSubscriptionToken<TMessage> toUnregister)
        {
            Router.UnregisterHandler(toUnregister);
        }

        public static void Send<TMessage>(TMessage message)
        {
            Router.RouteMessageToHandlers(message);
        }

        public static void Send<TRequest, TResponse>(TRequest request, Action<TResponse> responseHandler)
        {
            using (new ReplyContext<TResponse>(responseHandler))
            {
                Router.RouteMessageToHandlers(request);
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