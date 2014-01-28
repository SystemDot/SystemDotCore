using System;
using SystemDot.Ioc;
using SystemDot.Messaging.Handling;

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

        public static void RegisterHandler<TMessage>(Action<TMessage> toRegister)
        {
            Router.RegisterHandler(toRegister);
        }

        public static void UnregisterHandler<TMessage>(Action<TMessage> toUnregister)
        {
            Router.UnregisterHandler(toUnregister);
        }

        public static void Send<TMessage>(TMessage message)
        {
            Router.RouteMessageToHandlers(message);
        }
    }
}