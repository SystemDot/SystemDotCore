using System.Threading.Tasks;
using SystemDot.Environment;
using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static void Initialise(this BuilderConfiguration configuration)
        {
            configuration.GetIocContainer()
                .RegisterMultipleTypes()
                .FromAssemblyOf<Application>()
                .AllTypes()
                .ByClassAndInterface();

            configuration.BaseInitialise();
        }

        public static async Task InitialiseAsync(this BuilderConfiguration configuration)
        {
            configuration.GetIocContainer()
                .RegisterMultipleTypes()
                .FromAssemblyOf<Application>()
                .AllTypes()
                .ByClassAndInterface();

            await configuration.BaseInitialiseAsync();
        }
    }
}