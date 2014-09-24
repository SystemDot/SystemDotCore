using System.Threading.Tasks;
using SystemDot.Core;
using SystemDot.Environment;
using SystemDot.Files;
using SystemDot.Http;
using SystemDot.Http.Builders;
using SystemDot.Ioc;
using SystemDot.Serialisation;
using SystemDot.Storage.Changes.Upcasting;
using SystemDot.ThreadMarshalling;

namespace SystemDot.Configuration
{
    public static class BuilderConfigurationExtensions
    {
        public static void Initialise(this BuilderConfiguration configuration)
        {
            configuration.GetIocContainer().RegisterComponents();
            configuration.BaseInitialise();
        }

        public static async Task InitialiseAsync(this BuilderConfiguration configuration)
        {
            configuration.GetIocContainer().RegisterComponents(); 
            await configuration.BaseInitialiseAsync();
        }
    }

    public static class IocContainerExtensions
    {
        public static void RegisterComponents(this IIocContainer container)
        {
            container.RegisterInstance<IApplication, Application>();
            container.RegisterInstance<IFileSystem, FileSystem>();
            container.RegisterInstance<ILocalMachine, LocalMachine>();
            container.RegisterInstance<IHttpServerBuilder, HttpServerBuilder>();
            container.RegisterInstance<IWebRequestor, WebRequestor>();
            container.RegisterInstance<ISerialiser, JsonSerialiser>();
            container.RegisterInstance<ApplicationTypeActivator, ApplicationTypeActivator>();
            container.RegisterInstance<ChangeUpcasterRunner, ChangeUpcasterRunner>();
            container.RegisterInstance<IMainThreadMarshaller, MainThreadMarshaller>();
        }
    }
}