using SystemDot.Ioc.Specifications.TestTypes;
using SystemDot.Ioc.Specifications.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications
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

        It should_be_able_to_be_resolved = () => container.Resolve(typeof(ITestComponent)).ShouldBeOfExactType<TestComponent>();
    }
}