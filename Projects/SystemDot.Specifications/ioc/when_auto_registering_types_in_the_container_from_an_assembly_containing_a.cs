using System;
using SystemDot.Ioc;
using Machine.Fakes;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc
{
    [Subject("Ioc")]
    public class when_auto_registering_types_in_the_container_from_an_assembly_containing_a
    {
        static Exception exception;

        Because of = () => exception = Catch.Exception(() => new IocContainer()
            .RegisterFromAssemblyOf<when_auto_registering_types_in_the_container_from_an_assembly_containing_a>());

        It should_not_throw_any_exceptions = () => exception.ShouldBeNull();
    }
}