using SystemDot.Ioc;
using SystemDot.Specifications.ioc.TestTypes;
using SystemDot.Specifications.ioc.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc
{
    [Subject("Ioc")]
    public class when_resolving_an_instance_in_the_container_for_the_second_time 
    {
        static ITestComponent component1;
        static ITestComponent component2;

        static IocContainer container;

        Establish context = () =>
        {
            container = new IocContainer();
            container.RegisterInstance<ITestComponent, TestComponent>();
            component1 = container.Resolve<ITestComponent>();
        };

        Because of = () => component2 = container.Resolve<ITestComponent>();

        It should_be_the_same_object = () => component2.ShouldBeTheSameAs(component1);
    }
}