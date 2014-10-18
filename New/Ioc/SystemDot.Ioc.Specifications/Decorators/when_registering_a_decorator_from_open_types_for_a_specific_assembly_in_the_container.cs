using SystemDot.Core;
using SystemDot.Ioc.Specifications.MultpleTypes;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications.Decorators
{
    [Subject("Ioc")]
    public class when_registering_a_decorator_from_open_types_for_a_specific_assembly_in_the_container
    {
        static IocContainer container;
        static OpenTypeComponent decorated;

        Establish context = () =>
        {
            container = new IocContainer();
            decorated = new OpenTypeComponent();
            container.RegisterInstance<IOpenTypeComponent<string>>(() => decorated);
        };

        Because of = () => container.DecorateMultipleTypes()
            .FromAssemblyOf<OpenTypeComponent>()
            .ThatImplementOpenType(typeof(IOpenTypeComponent<>))
            .WithOpenTypeDecorator(typeof(OpenTypeComponentDecorator<>));

        It should_be_able_to_be_resolve_the_first_implementor_of_the_open_type_decorated_with_the_open_type_decorator = () =>
            container.Resolve<IOpenTypeComponent<string>>()
                .As<OpenTypeComponentDecorator<string>>()
                .Target.ShouldBeTheSameAs(decorated);
    }
}