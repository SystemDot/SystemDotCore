using SystemDot.Configuration;

namespace SystemDot.EventSourcing.Configuration
{
    public class EventSourcingBuilderConfiguration
    {
        readonly IBuilderConfiguration config;

        public EventSourcingBuilderConfiguration(IBuilderConfiguration config)
        {
            this.config = config;
        }

        public IBuilderConfiguration GetBuilderConfiguration()
        {
            return config;
        }
    }
}