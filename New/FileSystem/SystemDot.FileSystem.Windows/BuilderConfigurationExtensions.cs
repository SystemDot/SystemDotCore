using SystemDot.Bootstrapping;

namespace SystemDot.FileSystem
{
    public static class BuilderConfigurationExtensions
    {
        public static BootstrapBuilderConfiguration UseFileSystem(this BootstrapBuilderConfiguration configuration)
        {
            return configuration.RegisterBuildAction(c => c.RegisterInstance<IFileHelper, FileHelper>());
        }
    }
}