using System.Threading.Tasks;

namespace SystemDot.Bootstrapping
{
    public static class BootstrapBuilderConfigurationExtensions
    {
        public static async Task InitialiseAsync(this BootstrapBuilderConfiguration configuration)
        {
            configuration.GetIocContainer().RegisterComponents(); 
            await configuration.BaseInitialiseAsync();
        }
    }
}