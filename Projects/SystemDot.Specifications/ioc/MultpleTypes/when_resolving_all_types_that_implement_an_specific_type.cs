using System.Collections.Generic;
using System.Linq;
using SystemDot.Ioc;
using SystemDot.Specifications.ioc.TestTypes;
using SystemDot.Specifications.ioc.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc.MultpleTypes
{
    [Subject("Ioc")]
    public class when_resolving_all_types_that_implement_an_specific_type
    {
        static IocContainer container;
        static IEnumerable<ITestComponent> resolved;

        Establish context = () =>
        {
            container = new IocContainer();
            
            container
                .RegisterMultipleTypes()
                .FromAssemblyOf<when_resolving_all_types_that_implement_an_specific_type>()
                .ThatImplementType<ITestComponent>()
                .ByClass();
        };

        Because of = () => resolved = container.ResolveMutipleTypes().ThatImplement<ITestComponent>();

        It should_be_able_to_resolve_the_first_implementation_of_the_specified_interface = () => resolved.OfType<TestComponent>().ShouldNotBeEmpty();

        It should_be_able_to_resolve_the_second_implementation_of_the_specified_interface = () => resolved.OfType<AnotherTestComponent>().ShouldNotBeEmpty();
    }
}