using SystemDot.Ioc;

namespace SystemDot.Serialisation.Json.Configuration
{
    public static class IocContainerExtensions
    {
        public static void RegisterJsonSerialisation(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<JsonSerialiser>();
        }
    }
}