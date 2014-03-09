using SystemDot.Environment;
using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static void Initialise(this BuilderConfiguration configuration)
        {
            configuration.GetIocContainer().RegisterFromAssemblyOf<Application>();
            configuration.BaseInitialise();
        }
    }
}