using SystemDot.Specifications.ioc.TestTypes;

namespace SystemDot.Specifications.ioc.Decorators
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