using SystemDot.Configuration;
using SystemDot.Messaging.Simple;

namespace SystemDot.Messaging.Handling.Configuration
{
    public class ConfigurationBuilderComponent : IConfigurationBuilderComponent
    {
        public void Configure(ConfigurationBuilder builder)
        {
            builder.RegisterBuildAction(c => Messenger.RegisterHandlersFromContainer<IMessageHandler>(c), BuildOrder.VeryLate);
        }
    }
}