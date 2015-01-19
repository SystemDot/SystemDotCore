using SystemDot.Bootstrapping;

namespace SystemDot.Environment
{
    public static class BuilderConfigurationExtensions
    {
        public static BootstrapBuilderConfiguration UseEnvironment(this BootstrapBuilderConfiguration configuration)
        {
            return configuration.RegisterBuildAction(c => c.RegisterInstance<ILocalMachine, LocalMachine>());
        }
    }
}