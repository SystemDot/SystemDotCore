using SystemDot.Ioc.Specifications.MultpleTypes;

namespace SystemDot.Ioc.Specifications.Decorators
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