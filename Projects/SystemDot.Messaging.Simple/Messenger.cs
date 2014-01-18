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

        public static void Send<TMessage>(TMessage message)
        {
            Router.RouteMessageToHandlers(message);
        }
    }
}