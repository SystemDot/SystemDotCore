using SystemDot.Bootstrapping;

namespace SystemDot.ThreadMarshalling
{
    public static class BuilderConfigurationExtensions
    {
        public static BootstrapBuilderConfiguration UseThreadMarshalling(this BootstrapBuilderConfiguration configuration)
        {
            return configuration.RegisterBuildAction(c => c.RegisterInstance<IMainThreadMarshaller, MainThreadMarshaller>());
        }
    }
}