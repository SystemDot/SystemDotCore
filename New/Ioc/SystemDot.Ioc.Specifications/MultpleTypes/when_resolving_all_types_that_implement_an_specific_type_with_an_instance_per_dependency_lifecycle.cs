using System.Collections.Generic;
using System.Linq;
using SystemDot.Ioc.Specifications.TestTypes;
using SystemDot.Ioc.Specifications.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications.MultpleTypes
{
    [Subject("Ioc")]
    public class when_resolving_all_types_that_implement_an_specific_type_with_an_instance_per_dependency_lifecycle
    {
        static IocContainer container;
        static IEnumerable<ITestComponent> firstResolve;
        static IEnumerable<ITestComponent> secondResolve;

        Establish context = () =>
        {
            container = new IocContainer();

            container
                .RegisterMultipleTypes()
                .FromAssemblyOf<when_resolving_all_types_that_implement_an_specific_type>()
                .ThatImplementType<ITestComponent>()
                .ByClass(DependencyLifecycle.InstancePerDependency);
        };

        Because of = () =>
        {
            firstResolve = container.ResolveMutipleTypes().ThatImplement<ITestComponent>();
            secondResolve = container.ResolveMutipleTypes().ThatImplement<ITestComponent>();
        };

        It should_resolve_the_first_component_as_a_different_instance_to_the_first_time_it_was_resolved = () =>
            secondResolve.OfType<TestComponent>().ShouldNotBeTheSameAs(firstResolve.OfType<TestComponent>());

        It should_resolve_the_second_component_as_a_different_instance_to_the_first_time_it_was_resolved = () =>
            secondResolve.OfType<AnotherTestComponent>().ShouldNotBeTheSameAs(firstResolve.OfType<AnotherTestComponent>());

    }
}