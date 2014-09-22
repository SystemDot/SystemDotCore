using SystemDot.Core;
using SystemDot.Ioc;
using SystemDot.Specifications.ioc.MultpleTypes;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc.Decorators
{
    [Subject("Ioc")]
    public class when_registering_a_open_type_decorator_for_an_instance_in_the_container
    {
        static IocContainer container;
        static OpenTypeComponent decorated;

        Establish context = () =>
        {
            container = new IocContainer();
            decorated = new OpenTypeComponent();
            container.RegisterInstance<OpenTypeComponent>(() => decorated);
        };

        Because of = () => container.RegisterOpenTypeDecorator(typeof(OpenTypeComponent), typeof(OpenTypeComponentDecorator<>));

        It should_be_able_to_be_resolved_decorated_with_the_decorator = () =>
            container.Resolve(typeof(OpenTypeComponent))
                .As<OpenTypeComponentDecorator<string>>()
                    .Target.ShouldBeTheSameAs(decorated);
    }
}