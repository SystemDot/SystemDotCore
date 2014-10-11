using System.Threading.Tasks;
using SystemDot.Ioc;
using SystemDot.Reflection;

namespace SystemDot.Bootstrapping
{
    public static class BuilderConfigurationExtensions
    {
        public static async Task InitialiseAsync(this BootstrapBuilderConfiguration configuration)
        {
            configuration.GetIocContainer().RegisterComponents(); 
            await configuration.BaseInitialiseAsync();
        }
        
        public static void Initialise(this BootstrapBuilderConfiguration configuration)
        {
            configuration.GetIocContainer().RegisterComponents(); 
            configuration.BaseInitialise();
        }

        static void RegisterComponents(this IIocContainer container)
        {
            container.RegisterInstance<IApplication, Application>();
        }
    }
}