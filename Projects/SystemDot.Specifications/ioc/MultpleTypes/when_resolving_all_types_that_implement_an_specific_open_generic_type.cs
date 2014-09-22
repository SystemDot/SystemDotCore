using System.Collections;
using System.Linq;
using SystemDot.Ioc;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc.MultpleTypes
{
    [Subject("Ioc")]
    public class when_resolving_all_types_that_implement_an_specific_open_generic_type
    {
        static IocContainer container;
        static IEnumerable resolved;

        Establish context = () =>
        {
            container = new IocContainer();

            container
                .RegisterMultipleTypes()
                .FromAssemblyOf<when_resolving_all_types_that_implement_an_specific_type>()
                .AllTypes()
                .ByClass();
        };

        Because of = () => resolved = container.ResolveMutipleTypes().ThatImplementOpenType(typeof(IOpenTypeComponent<>));

        It should_be_able_to_resolve_the_first_implementation_of_the_specified_interface = () => resolved.OfType<OpenTypeComponent>().ShouldNotBeEmpty();

        It should_be_able_to_resolve_the_second_implementation_of_the_specified_interface = () => resolved.OfType<OtherOpenTypeComponent>().ShouldNotBeEmpty();
    }
}