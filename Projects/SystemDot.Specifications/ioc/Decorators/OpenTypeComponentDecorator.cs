using SystemDot.Specifications.ioc.MultpleTypes;

namespace SystemDot.Specifications.ioc.Decorators
{
    public class OpenTypeComponentDecorator<T> : IOpenTypeComponent<T>
    {
        public IOpenTypeComponent<T> Target { get; private set; }

        public OpenTypeComponentDecorator(IOpenTypeComponent<T> target)
        {
            Target = target;
        }
    }
}