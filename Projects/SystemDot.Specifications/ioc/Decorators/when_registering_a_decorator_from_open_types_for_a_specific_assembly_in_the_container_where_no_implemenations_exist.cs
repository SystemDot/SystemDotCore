using SystemDot.Core;
using SystemDot.Files;
using SystemDot.Ioc;
using SystemDot.Specifications.ioc.MultpleTypes;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc.Decorators
{
    [Subject("Ioc")]
    public class when_registering_a_decorator_from_open_types_for_a_specific_assembly_in_the_container_where_no_implemenations_exist
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
            .FromAssemblyOf<FileLocation>()
            .ThatImplementOpenType(typeof(IOpenTypeComponent<>))
            .WithOpenTypeDecorator(typeof(OpenTypeComponentDecorator<>));

        It should_not_be_able_to_be_resolve_the_first_implementor_of_the_open_type_decorated_with_the_open_type_decorator = () =>
            container.Resolve<IOpenTypeComponent<string>>()
                .ShouldNotBeOfType(typeof(OpenTypeComponentDecorator<string>));
    }
}