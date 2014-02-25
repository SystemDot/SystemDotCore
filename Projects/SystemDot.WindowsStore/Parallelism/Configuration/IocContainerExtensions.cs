using SystemDot.Ioc;

namespace SystemDot.Parallelism.Configuration
{
    public static class IocContainerExtensions
    {
        public static void RegisterParallelism(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<TaskScheduler>();
        }
    }
}
