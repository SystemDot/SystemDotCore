using SystemDot.Ioc;

namespace SystemDot.Bootstrapping
{
    public class BootstrapContainerConfiguration
    {
        public BootstrapBuilderConfiguration ResolveReferencesWith(IIocContainer toResolveWith)
        {
            return new BootstrapBuilderConfiguration(toResolveWith);
        }
    }
}