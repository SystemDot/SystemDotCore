using SystemDot.Bootstrapping;
using SystemDot.Ioc;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SystemDot.ThreadMarshalling.Specifications
{
    [Binding]
    public class ThreadMarshallingSteps
    {
        readonly IIocContainer container;

        public ThreadMarshallingSteps()
        {
            container = new IocContainer();
        }

        [When(@"I have initialised bootstrapping")]
        public void WhenIHaveInitialisedBootstrapping()
        {
            Bootstrap.Application().ResolveReferencesWith(container).UseThreadMarshalling().Initialise();
        }

        [Then(@"I should be able to resolve the marshaller")]
        public void ThenIShouldBeAbleToResolveTheMarshaller()
        {
            container.Resolve<IMainThreadMarshaller>().Should().BeOfType<MainThreadMarshaller>();
        }
    }
}
