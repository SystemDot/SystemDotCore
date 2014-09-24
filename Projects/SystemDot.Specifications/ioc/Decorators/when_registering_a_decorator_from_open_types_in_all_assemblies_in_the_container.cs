using SystemDot.Core;
using SystemDot.Ioc;
using SystemDot.Specifications.ioc.MultpleTypes;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc.Decorators
{
    [Subject("Ioc")]
    public class when_registering_a_decorator_from_open_types_in_all_assemblies_in_the_container
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
            .FromAllAssemblies()
            .ThatImplementOpenType(typeof(IOpenTypeComponent<>))
            .WithOpenTypeDecorator(typeof(OpenTypeComponentDecorator<>));

        It should_be_able_to_be_resolve_the_first_implementor_of_the_open_type_decorated_with_the_open_type_decorator = () =>
            container.Resolve<IOpenTypeComponent<string>>()
                .As<OpenTypeComponentDecorator<string>>()
                    .Target.ShouldBeTheSameAs(decorated);
    }

    [Subject("Ioc")]
    public class when_registering_multiple_decorators_from_open_types_in_all_assemblies_in_the_container
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
            .FromAllAssemblies()
            .ThatImplementOpenType(typeof(IOpenTypeComponent<>))
            .WithOpenTypeDecorators(
                typeof(OpenTypeComponentDecorator<>), 
                typeof(OtherOpenTypeComponentDecorator<>));

        It should_be_able_to_be_resolved_decorated_with_two_decorators = () =>
            container.Resolve<IOpenTypeComponent<string>>()
                .As<OtherOpenTypeComponentDecorator<string>>()
                    .Target.As<OpenTypeComponentDecorator<string>>()
                        .Target.ShouldBeTheSameAs(decorated);
    }
}