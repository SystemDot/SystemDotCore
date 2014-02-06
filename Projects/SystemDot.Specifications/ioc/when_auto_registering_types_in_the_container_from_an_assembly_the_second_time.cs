using SystemDot.Ioc;
using SystemDot.Specifications.ioc.TestTypes;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc
{
    [Subject("Ioc")]
    public class when_auto_registering_types_in_the_container_from_an_assembly_the_second_time 
    {
        static ITestInterface1 instance1;
        static ITestInterface1 instance2;
        static IocContainer container;

        Establish context = () => 
        {
            container = new IocContainer();
            container.RegisterFromAssemblyOf<when_auto_registering_types_in_the_container_from_an_assembly_the_second_time>();
            instance1 = container.Resolve<ITestInterface1>();
        };

        Because of = () =>
        {
            container.RegisterFromAssemblyOf<when_auto_registering_types_in_the_container_from_an_assembly_the_second_time>();
            instance2 = container.Resolve<ITestInterface1>();
        };

        It should_resolve_the_same_instance_as_with_the_first_registration = () =>
            instance1.ShouldBeTheSameAs(instance2);
    }
}