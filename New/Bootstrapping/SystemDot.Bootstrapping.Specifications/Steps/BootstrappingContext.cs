using SystemDot.Ioc;

namespace SystemDot.Bootstrapping.Specifications.Steps
{
    public class BootstrappingContext
    {
        public IocContainer Container { get; private set; }
        public BootstrapBuilderConfiguration Config { get; private set; }

        public BootstrappingContext(IocContainer container)
        {
            Container = container;
            Config = Bootstrap.Application().ResolveReferencesWith(container);
        }
    }
}