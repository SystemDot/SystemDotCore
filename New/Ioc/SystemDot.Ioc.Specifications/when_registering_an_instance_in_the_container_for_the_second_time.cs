using SystemDot.Ioc.Specifications.TestTypes;
using SystemDot.Ioc.Specifications.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications
{
    [Subject("Ioc")]
    public class when_registering_an_instance_in_the_container_for_the_second_time
    {
        static ITestComponent instance;
        static IocContainer container;

        Establish context = () =>
        {
            container = new IocContainer();
            container.RegisterInstance<ITestComponent, TestComponent>();
            instance = container.Resolve<ITestComponent>();
            container.RegisterInstance<ITestComponent, TestComponent>();
        };

        It should_resolve_the_same_instance_as_with_the_first_registration = () => 
            container.Resolve<ITestComponent>().ShouldBeTheSameAs(instance);
    }
}