using System;
using SystemDot.Ioc.Specifications.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications
{
    [Subject("Ioc")]
    public class when_resolving_a_type_by_interface_that_is_not_registered
    {
        static Exception exception;

        Because of = () => exception = Catch.Exception(() => new IocContainer().Resolve<ITestComponent>());

        It should_throw_a_type_not_registered_exception_wrapped_in_a_cannot_resolve_type_exception = () => exception.ShouldBeOfExactType<CannotResolveTypeException>();

        It should_throw_a_type_not_registered_exception = () => exception.InnerException.ShouldBeOfExactType<TypeNotRegisteredException>();

        It should_say_which_type_was_not_registered = () => exception.Message.ShouldEqual("Type \"ITestComponent\" cannot be resolved in the container.");
    }
}