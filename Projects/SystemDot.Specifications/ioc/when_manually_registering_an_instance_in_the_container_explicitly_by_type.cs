using SystemDot.Ioc;
using SystemDot.Specifications.ioc.TestTypes;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc
{
    [Subject("Ioc")]
    public class when_manually_registering_an_instance_in_the_container_explicitly_by_type
    {
        static IocContainer container;

        Establish context = () =>
        {
            container = new IocContainer();
        };

        Because of = () => container.RegisterInstance(typeof(ITestComponent), typeof(TestComponent));

        It should_be_able_to_be_resolved = () => container.Resolve(typeof(ITestComponent)).ShouldBeOfType<TestComponent>();
    }
}