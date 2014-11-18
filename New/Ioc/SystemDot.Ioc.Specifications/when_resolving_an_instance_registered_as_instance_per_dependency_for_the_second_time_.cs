using SystemDot.Ioc.Specifications.TestTypes;
using SystemDot.Ioc.Specifications.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications
{
    [Subject("Ioc")]
    public class when_resolving_an_instance_registered_as_instance_per_dependency_for_the_second_time_ 
    {
        static ITestComponent component1;
        static ITestComponent component2;

        static IocContainer container;

        Establish context = () =>
        {
            container = new IocContainer();
            container.RegisterInstance<ITestComponent, TestComponent>(DependencyLifecycle.InstancePerDependency);
            component1 = container.Resolve<ITestComponent>();
        };

        Because of = () => component2 = container.Resolve<ITestComponent>();

        It should_not_be_the_same_object = () => component2.ShouldNotBeTheSameAs(component1);
    }
}