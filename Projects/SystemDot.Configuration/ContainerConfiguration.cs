using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public class ContainerConfiguration
    {
        public IBuilderConfiguration ResolveReferencesWith(IIocContainer toResolveWith)
        {
            return new BuilderConfiguration(toResolveWith);
        }
    }
}