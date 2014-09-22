using SystemDot.Ioc;
using SystemDot.Specifications.ioc.TestTypes;
using SystemDot.Specifications.ioc.TestTypes.Interfaces;
using Machine.Specifications;

namespace SystemDot.Specifications.ioc
{
    [Subject("Ioc")]
    public class when_manually_registering_an_instance_in_the_container 
    {
        static AnotherInheritingComponent created;
        static IocContainer container;

        Establish context = () => 
        {
            container = new IocContainer();
            created = new AnotherInheritingComponent();
            container.RegisterInstance<IThirdTestComponent, ThirdTestComponent>();
        };

        Because of = () => container.RegisterInstance<IAnotherTestComponent>(() => created);

        It should_be_able_to_be_resolved = () => container.Resolve<IAnotherTestComponent>().ShouldBeTheSameAs(created);
    }
}