using SystemDot.Specifications.ioc.MultpleTypes;

namespace SystemDot.Specifications.ioc.Decorators
{
    public class OtherOpenTypeComponentDecorator<T> : IOpenTypeComponent<T>
    {
        public IOpenTypeComponent<T> Target { get; private set; }

        public OtherOpenTypeComponentDecorator(IOpenTypeComponent<T> target)
        {
            Target = target;
        }
    }
}