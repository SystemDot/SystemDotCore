using SystemDot.Configuration;

namespace SystemDot.EventSourcing.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static EventSourcingDispatchEventsConfiguration UseEventSourcing(this IBuilderConfiguration config)
        {
            return new EventSourcingDispatchEventsConfiguration(config);
        }
    }
}