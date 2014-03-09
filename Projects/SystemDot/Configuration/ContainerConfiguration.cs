using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public class ContainerConfiguration
    {
        public BuilderConfiguration ResolveReferencesWith(IIocContainer toResolveWith)
        {
            return new BuilderConfiguration(toResolveWith);
        }
    }
}