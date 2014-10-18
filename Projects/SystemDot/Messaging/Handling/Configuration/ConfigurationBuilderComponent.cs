using SystemDot.Bootstrapping;

namespace SystemDot.Messaging.Handling.Configuration
{
    public class BootstrapBuilderComponent : IBootstrapBuilderComponent
    {
        public void Configure(BootstrapBuilder builder)
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