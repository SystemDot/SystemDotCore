using System;
using SystemDot.Ioc.Specifications.TestTypes;
using SystemDot.Ioc.Specifications.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications
{
    [Subject("Ioc")]
    public class when_veryfying_the_container_in_a_complete_state
    {
        static IIocContainer container;
        static Exception exception;

        Establish context = () =>
        {
            container = new IocContainer();
            container.RegisterInstance<ITestComponent, TestComponent>();
            container.RegisterInstance<ITestComponentWithParameters, TestComponentWithParameters>();
        };

        Because of = () => exception = Catch.Exception(() => container.Verify());

        It should_throw_an_unverifiable_exception = () => exception.ShouldBeOfExactType<ContainerUnverifiableException>();
    }
}