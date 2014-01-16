using SystemDot.Ioc;
using SystemDot.Querying.Repositories;

namespace SystemDot.Querying.Configuration
{
    internal static class IocContainerExtensions
    {
        public static void RegisterQuerying(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<IQueryableRepository>();
        }

        public static ReadModelBuilder ResolveReadModelBuilder(this IIocContainer container)
        {
            return container.Resolve<ReadModelBuilder>();
        }
    }
}