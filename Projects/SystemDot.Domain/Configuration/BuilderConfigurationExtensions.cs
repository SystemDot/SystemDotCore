using SystemDot.Configuration;

namespace SystemDot.Domain.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static IBuilderConfiguration UseDomain(this IBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterDomain());
            return config;
        }
    }
}