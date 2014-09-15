using SystemDot.Ioc;
using SystemDot.Specifications.ioc.TestTypes;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc
{
    [Subject("Ioc")]
    public class when_registering_a_decorator_for_an_instance_in_the_container
    {
        static IocContainer container;

        Establish context = () =>
        {
            container = new IocContainer();
            container.RegisterInstance<TestComponent, TestComponent>();
        };

        Because of = () => container.RegisterDecorator<TestComponentDecorator, TestComponent>();

        It should_be_able_to_be_resolved_wrapped_in_the_decorator = () =>
            container.Resolve<TestComponent>().ShouldBeOfType<TestComponentDecorator>();
    }

    public class TestComponentDecorator : TestComponent
    {
    }
}