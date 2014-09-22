using SystemDot.Core;
using SystemDot.Ioc;
using SystemDot.Specifications.ioc.TestTypes;
using SystemDot.Specifications.ioc.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc
{
    [Subject("Ioc")]
    public class when_registering_an_instance_in_the_container 
    {
        static ITestComponent resolvedByGenericParamater;
        static ITestComponent resolvedByTypeOf;
        static IocContainer container;

        Establish context = () =>
        {
            container = new IocContainer();
            container.RegisterInstance<ITestComponent, TestComponent>();
        };

        Because of = () =>
        {
            resolvedByGenericParamater = container.Resolve<ITestComponent>();
            resolvedByTypeOf = container.Resolve(typeof(ITestComponent)).As<ITestComponent>();
        };

        It should_be_able_to_be_resolved_by_generic_parameter = () => resolvedByGenericParamater.ShouldBeOfType<TestComponent>();

        It should_be_able_to_be_resolved_by_type_of = () =>  resolvedByTypeOf.ShouldBeOfType<TestComponent>();
    }
}