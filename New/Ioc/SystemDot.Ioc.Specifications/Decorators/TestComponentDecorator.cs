using SystemDot.Ioc.Specifications.TestTypes;

namespace SystemDot.Ioc.Specifications.Decorators
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