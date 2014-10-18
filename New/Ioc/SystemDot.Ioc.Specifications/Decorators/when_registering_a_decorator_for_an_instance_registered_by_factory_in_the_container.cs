using SystemDot.Core;
using SystemDot.Ioc.Specifications.TestTypes;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications.Decorators
{
    [Subject("Ioc")]
    public class when_registering_a_decorator_for_an_instance_registered_by_factory_in_the_container
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

        It should_be_able_to_be_resolved_decorated_with_the_decorator = () =>
            container.Resolve<TestComponent>().As<TestComponentDecorator>().Target.ShouldBeTheSameAs(decorated);
    }
}