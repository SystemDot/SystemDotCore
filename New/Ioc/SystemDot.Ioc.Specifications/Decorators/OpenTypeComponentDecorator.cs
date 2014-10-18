using SystemDot.Ioc.Specifications.MultpleTypes;

namespace SystemDot.Ioc.Specifications.Decorators
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