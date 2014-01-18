using SystemDot.Ioc;

namespace SystemDot.Files.Windows.Configuration
{
    public static class IocContainerExtensions
    {
        public static void RegisterFileSystem(this IIocContainer container)
        {
            container.RegisterFromAssemblyOf<FileSystem>();
        }
    }
}