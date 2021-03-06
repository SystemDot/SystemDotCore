using Machine.Specifications;

namespace SystemDot.Ioc.Specifications.MultpleTypes
{
    [Subject("Ioc")]
    public class when_registering_all_implementations_of_open_generic_types_in_the_container_by_implementation
    {
        static IocContainer container;

        Establish context = () =>
        {
            container = new IocContainer();
        };

        Because of = () => 
            container
                .RegisterMultipleTypes()
                .FromAssemblyOf<OpenTypeComponent>()
                .ThatImplementOpenType(typeof(IOpenTypeComponent<>))
                .ByClass();

        It should_be_able_to_resolve_an_implementation = () => container.Resolve<OpenTypeComponent>().ShouldNotBeNull();

        It should_be_able_to_resolve_another_implementation = () => container.Resolve<OtherOpenTypeComponent>().ShouldNotBeNull();
    }
}