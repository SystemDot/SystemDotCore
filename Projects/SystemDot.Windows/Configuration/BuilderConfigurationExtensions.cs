using System.Threading.Tasks;

namespace SystemDot.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static async Task InitialiseAsync(this BuilderConfiguration configuration)
        {
            configuration.GetIocContainer().RegisterComponents(); 
            await configuration.BaseInitialiseAsync();
        }
    }
}