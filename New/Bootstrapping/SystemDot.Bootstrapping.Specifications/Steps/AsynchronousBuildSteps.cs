using System.Threading.Tasks;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SystemDot.Bootstrapping.Specifications.Steps
{
    [Binding]
    public class AsynchronousBuildSteps
    {
        readonly BootstrappingContext context;

        public AsynchronousBuildSteps(BootstrappingContext context)
        {
            this.context = context;
        }

        [When(@"I build the bootstrapper asynchronously")]
        public void WhenIBuildTheBootstrapperAsynchronously()
        {
            context.Config.InitialiseAsync().Wait();
        }

        [Given(@"I have registered an asynchronous build action with the bootstrapper to register a component with ioc")]
        public void GivenIHaveRegisteredAnAsynchronousBuildActionWithTheBootstrapperToRegisterAComponentWithIoc()
        {
            context.Config.RegisterBuildAction(async c => 
            {
                c.RegisterInstance<AsynchronouslyRegisteredTestComponent, AsynchronouslyRegisteredTestComponent>();
                await Task.Delay(1);
            });
        }

        [Then(@"I should be able to resolve the asynchronously registered component from ioc")]
        public void ThenIShouldBeAbleToResolveFromIoc()
        {
            context.Container.ComponentExists<AsynchronouslyRegisteredTestComponent>().Should().BeTrue();
        }
    }
}