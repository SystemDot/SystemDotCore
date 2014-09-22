using SystemDot.Configuration;
using SystemDot.Core.Collections;
using SystemDot.Ioc;
using SystemDot.Messaging.Simple;

namespace SystemDot.Messaging.Handling.Configuration
{
    public class ConfigurationBuilderComponent : IConfigurationBuilderComponent
    {
        public void Configure(ConfigurationBuilder builder)
        {
            builder.RegisterBuildAction(
                c => c.ResolveMutipleTypes()
                    .ThatImplementOpenType(typeof(IMessageHandler<>))
                    .ForEach(Messenger.RegisterHandler), 
                BuildOrder.VeryLate);
        }
    }
}