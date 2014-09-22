using SystemDot.Specifications.ioc.TestTypes;

namespace SystemDot.Specifications.ioc.Decorators
{
    public class TestComponentDecorator : TestComponent
    {
        public TestComponent Target { get; private set; }

        public TestComponentDecorator(TestComponent target)
        {
            Target = target;
        }
    }
}