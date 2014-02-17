using SystemDot.Http.Builders;
using SystemDot.Ioc;

namespace SystemDot.Http.Configuration
{
    public static class IocContainerExtensions
    {
        public static void RegisterHttp(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<HttpServerBuilder>();
        }
    }
}
