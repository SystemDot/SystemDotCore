using SystemDot.Configuration;

namespace SystemDot.Messaging.Handling.Configuration
{
    public class ConfigurationBuilderComponent : IConfigurationBuilderComponent
    {
        public void Configure(ConfigurationBuilder builder)
        {
            builder.RegisterBuildAction(
                c => c.RegisterOpenTypeHandlersWithMessenger(typeof(IMessageHandler<>)),
                BuildOrder.VeryLate);

            builder.RegisterBuildAction(
                c => c.RegisterOpenTypeHandlersWithMessenger(typeof(IAsyncMessageHandler<>)),
                BuildOrder.VeryLate);
        }
    }
}