using SystemDot.Ioc;

namespace SystemDot.Serialisation.Configuration
{
    public static class IocContainerExtensions
    {
        public static void RegisterJsonSerialisation(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<JsonSerialiser>();
        }
    }
}