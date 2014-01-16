using SystemDot.Configuration;

namespace SystemDot.Querying.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static IBuilderConfiguration UseQuerying(this IBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterQuerying());
            config.RegisterBuildAction(c => c.ResolveReadModelBuilder().Build(), BuildOrder.SystemOnlyLast);
            return config;
        }
    }
}