using SystemDot.Ioc.Specifications.TestTypes;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications
{
    [Subject("Ioc")]
    public class when_resolving_a_type_that_has_a_dependency_on_a_concrete_type_that_is_not_registered
    {
        static TestComponentWithConcreteDependency component;
        
        Because of = () => component = new IocContainer().Resolve<TestComponentWithConcreteDependency>();

        It should_resolve_the_component = () => component.ShouldNotBeNull();

        It should_resolve_the_components_dependency = () => component.Dependency.ShouldNotBeNull();
    }
}