using SystemDot.Core;
using SystemDot.Ioc.Specifications.TestTypes;
using SystemDot.Ioc.Specifications.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Ioc.Specifications
{
    [Subject("Ioc")]
    public class when_registering_an_instance_with_parameters_in_the_container 
    {
        static IocContainer container;

        Establish context = () => 
        {
            container = new IocContainer();
       
            container.RegisterInstance<ITestComponent, TestComponent>();

            container.RegisterInstance<IAnotherTestComponent>(() => new AnotherTestComponentOnAnotherInterface(
                container.Resolve<IThirdTestComponent>(),
                new AnotherInheritingComponent()));

            container.RegisterInstance<IThirdTestComponent, ThirdTestComponent>();
        };

        Because of = () => container.RegisterInstance<ITestComponentWithParameters, TestComponentWithParameters>();

        It should_be_able_to_be_resolved = () => 
            container.Resolve<ITestComponentWithParameters>().ShouldBeOfExactType(typeof(TestComponentWithParameters));

        It should_have_the_correct_first_parameter = () => 
            container.Resolve<ITestComponentWithParameters>().As<TestComponentWithParameters>()
                .FirstParameter.ShouldBeOfExactType<TestComponent>();

        It should_have_the_correct_second_parameter = () => 
            container.Resolve<ITestComponentWithParameters>().As<TestComponentWithParameters>()
                .SecondParameter.ShouldBeOfExactType<AnotherTestComponentOnAnotherInterface>();

        It should_have_the_correct_dependency_in_the_second_parameter = () =>
            container.Resolve<ITestComponentWithParameters>().As<TestComponentWithParameters>()
                .SecondParameter.As<AnotherTestComponentOnAnotherInterface>().FirstParameter.ShouldBeOfExactType<ThirdTestComponent>();
    }
}