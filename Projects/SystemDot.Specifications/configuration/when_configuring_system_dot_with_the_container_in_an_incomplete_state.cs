using System;
using SystemDot.Configuration;
using SystemDot.Ioc;
using SystemDot.Specifications.ioc.TestTypes;
using SystemDot.Specifications.ioc.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Specifications.configuration
{
    [Subject(SpecificationGroup.Description)]
    public class when_configuring_system_dot_with_the_container_in_an_incomplete_state
    {
        static Exception exception;
        
        Because of = () => exception = Catch.Exception(() => Configure
            .SystemDot()
            .ResolveReferencesWith(new IocContainer())
            .RegisterBuildAction(c => c.RegisterInstance<ITestComponentWithParameters, TestComponentWithParameters>())
            .InitialiseAsync().Wait());

        It should_throw_an_unverifiable_exception = () => exception.InnerException.ShouldBeOfType<ContainerUnverifiableException>();
    }
}