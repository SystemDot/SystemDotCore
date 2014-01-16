using SystemDot.Configuration;

namespace App.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static IBuilderConfiguration UseTestApp(this IBuilderConfiguration config)
        {
            config.RegisterBuildAction(c => c.RegisterTestApp());
            return config;
        }
    }
}