using SystemDot.Configuration;

namespace SystemDot.Logging.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static IBuilderConfiguration LoggingWith(this IBuilderConfiguration config, ILoggingMechanism loggingMechanism)
        {
            config.RegisterBuildAction(c => c.RegisterInstance<ILoggingMechanism>(() => loggingMechanism));
            return config;
        }
    }
}
