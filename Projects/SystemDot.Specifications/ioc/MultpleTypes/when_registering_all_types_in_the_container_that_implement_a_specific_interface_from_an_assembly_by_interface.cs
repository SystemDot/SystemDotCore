using SystemDot.Ioc;
using SystemDot.Specifications.ioc.TestTypes;
using SystemDot.Specifications.ioc.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc.MultpleTypes
{
    [Subject("Ioc")]
    public class when_registering_all_types_in_the_container_that_implement_a_specific_interface_from_an_assembly_by_interface
    {
        static IocContainer container;

        Establish context = () => container = new IocContainer();

        Because of = () => container
            .RegisterMultipleTypes()
            .FromAssemblyOf<when_registering_all_types_in_the_container_from_an_assembly_by_interface>()
            .ThatImplementType<ITestComponent>()
            .ByClass();

        It should_be_able_to_resolve_the_first_componented_implementing_the_interface = () =>
            container.Resolve<TestComponent>().ShouldNotBeNull(); 
        
        It should_be_able_to_resolve_the_second_componented_implementing_the_interface = () =>
            container.Resolve<AnotherTestComponent>().ShouldNotBeNull();
    }
}