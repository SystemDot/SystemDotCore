using System;
using SystemDot.Ioc;
using SystemDot.Specifications.ioc.TestTypes;
using SystemDot.Specifications.ioc.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc
{
    [Subject("Ioc")]
    public class when_veryfying_the_container_in_an_incomplete_state
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

        It should_throw_an_unverifiable_exception = () => exception.ShouldBeOfType<ContainerUnverifiableException>();
    }
}