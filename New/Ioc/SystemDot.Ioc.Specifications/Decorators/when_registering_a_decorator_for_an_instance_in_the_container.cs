using SystemDot.Ioc.Specifications.TestTypes;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications.Decorators
{
    [Subject("Ioc")]
    public class when_registering_a_decorator_for_an_instance_in_the_container
    {
        static IocContainer container;
        static TestComponent decorated;

        Establish context = () =>
        {
            container = new IocContainer();
            decorated = new TestComponent();
            container.RegisterInstance<TestComponent>(() => decorated);
        };

        Because of = () => container.RegisterDecorator<TestComponentDecorator, TestComponent>();

        It should_be_able_to_be_resolved = () =>
            container.Resolve<TestComponent>().ShouldBeOfExactType<TestComponentDecorator>();
    }
}