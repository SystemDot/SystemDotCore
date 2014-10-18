using SystemDot.Core;
using SystemDot.Ioc.Specifications.TestTypes;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications.Decorators
{
    [Subject("Ioc")]
    public class when_registering_a_decorator_for_an_instance_already_decorated_in_the_container
    {
        static IocContainer container;
        static TestComponent decorated;

        Establish context = () =>
        {
            container = new IocContainer();
            decorated = new TestComponent();
            container.RegisterInstance<TestComponent>(() => decorated);
            container.RegisterDecorator<TestComponentDecorator, TestComponent>();
        };

        Because of = () => container.RegisterDecorator<OtherTestComponentDecorator, TestComponent>();

        It should_be_able_to_be_resolved_decorated_with_two_decorators = () =>
            container.Resolve<TestComponent>().As<OtherTestComponentDecorator>().Target.As<TestComponentDecorator>().Target.ShouldBeTheSameAs(decorated);
    }
}