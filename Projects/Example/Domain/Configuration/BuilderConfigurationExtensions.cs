using SystemDot.Configuration;

namespace Domain.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static IBuilderConfiguration UseTestDomain(this IBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterTestDomain());
            return config;
        }
    }
}