using SystemDot.Ioc.Specifications.TestTypes;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications.MultpleTypes
{
    [Subject("Ioc")]
    public class when_registering_all_types_in_the_container_from_an_assembly_by_implementation
    {
        static IocContainer container;

        Establish context = () => container = new IocContainer();

        Because of = () => container
            .RegisterMultipleTypes()
            .FromAssemblyOf<when_registering_all_types_in_the_container_from_an_assembly_by_implementation>()
            .AllTypes()
            .ByClass();

        It should_auto_register_a_concrete_type_by_the_concrete_type = () =>
            container.Resolve<TestTypeNotImplementingAnInterface>().ShouldBeOfExactType<TestTypeNotImplementingAnInterface>();

        It should_auto_register_a_concrete_type_implementing_an_interface_by_the_concrete_type = () =>
            container.Resolve<TestTypeImplementingAnInterface>().ShouldBeOfExactType<TestTypeImplementingAnInterface>();
    }
}