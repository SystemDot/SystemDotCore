using SystemDot.Ioc;
using SystemDot.Specifications.ioc.TestTypes;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc
{
    [Subject("Ioc")]
    public class when_auto_registering_types_in_the_container_from_an_assembly
    {
        static IocContainer container;

        Establish context = () => container = new IocContainer();
       
        Because of = () => container.RegisterFromAssemblyOf<when_auto_registering_types_in_the_container_from_an_assembly>();

        It should_auto_register_a_concrete_type_by_the_concrete_type = () =>
            container.Resolve<TestTypeNotImplementingAnInterface>().ShouldBeOfType<TestTypeNotImplementingAnInterface>();

        It should_auto_register_a_concrete_type_implementing_an_interface_by_the_interface = () =>
            container.Resolve<ITestInterface1>().ShouldBeOfType<TestTypeImplementingAnInterface>();

        It should_auto_register_a_concrete_type_implementing_an_interface_by_the_concrete_type = () =>
            container.Resolve<TestTypeImplementingAnInterface>().ShouldBeOfType<TestTypeImplementingAnInterface>();

        It should_not_auto_register_an_interface_without_concrete_type_implementing_it = () =>
            Catch.Exception(() => container.Resolve<ITestInterfaceWithNoConcreteImplementation>())
            	.ShouldBeOfType<TypeNotRegisteredException>();

        It should_not_auto_register_an_abstract_concrete_type = () =>
            Catch.Exception(() => container.Resolve<TestAbstractConcreteType>())
            	.ShouldBeOfType<TypeNotRegisteredException>();

        //It should_auto_register_a_derived_concrete_type_against_its_interface = () =>
        //    container.Resolve<ITestInterfaceOnDerivedConcreteType>().ShouldBeOfType<TestDerivedConcreteType>();
    }
}
