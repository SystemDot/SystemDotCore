using SystemDot.Configuration;
using SystemDot.Messaging.Simple;

namespace SystemDot.Messaging.Handling.Configuration
{
    public static class IocContainerExtensions
    {
        public static void RegisterAllMessageHandlers(this IBuilderConfiguration config)
        {
            config.RegisterBuildAction(Messenger.RegisterHandlersFromContainer<IMessageHandler>, BuildOrder.SystemOnlyLast);
        }
    }
}