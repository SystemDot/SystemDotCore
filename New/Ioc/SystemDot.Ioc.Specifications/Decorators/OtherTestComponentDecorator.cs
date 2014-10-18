using SystemDot.Ioc.Specifications.TestTypes;

namespace SystemDot.Ioc.Specifications.Decorators
{
    public class OtherTestComponentDecorator : TestComponent
    {
        public TestComponent Target { get; private set; }

        public OtherTestComponentDecorator(TestComponent target)
        {
            Target = target;
        }
    }
}