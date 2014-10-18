using SystemDot.Ioc.Specifications.TestTypes;
using SystemDot.Ioc.Specifications.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications.MultpleTypes
{
    [Subject("Ioc")]
    public class when_registering_all_types_in_the_container_from_an_assembly_by_implementation_and_interface
    {
        static IocContainer container;

        Establish context = () => container = new IocContainer();

        Because of = () => container
            .RegisterMultipleTypes()
            .FromAssemblyOf<when_registering_all_types_in_the_container_from_an_assembly_by_implementation>()
            .AllTypes()
            .ByClassAndInterface();

        It should_auto_register_a_concrete_type_by_the_concrete_type = () =>
            container.Resolve<TestTypeNotImplementingAnInterface>().ShouldBeOfExactType<TestTypeNotImplementingAnInterface>();

        It should_auto_register_a_concrete_type_implementing_an_interface_by_the_interface = () =>
            container.Resolve<ITestInterface1>().ShouldBeOfExactType<TestTypeImplementingAnInterface>();

        //It should_not_auto_register_an_interface_without_concrete_type_implementing_it = () =>
        //    Catch.Exception(() => container.Resolve<ITestInterfaceWithNoConcreteImplementation>())
        //        .ShouldBeOfExactType<TypeNotRegisteredException>();

        //It should_not_auto_register_an_abstract_concrete_type = () =>
        //    Catch.Exception(() => container.Resolve<TestAbstractConcreteType>())
        //        .ShouldBeOfExactType<TypeNotRegisteredException>();

        //It should_auto_register_a_derived_concrete_type_against_its_interface = () =>
        //    container.Resolve<ITestInterfaceOnDerivedConcreteType>().ShouldBeOfExactType<TestDerivedConcreteType>();
    }
}