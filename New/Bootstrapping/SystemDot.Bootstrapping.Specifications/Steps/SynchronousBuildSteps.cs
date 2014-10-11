using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace SystemDot.Bootstrapping.Specifications.Steps
{
    [Binding]
    public class SynchronousBuildSteps
    {
        readonly List<int> collection;
        readonly BootstrappingContext context;

        public SynchronousBuildSteps(BootstrappingContext context)
        {
            this.context = context;
            collection = new List<int>();
        }

        [Given(@"I have registered a build action with the bootstrapper to register a component with ioc")]
        public void GivenIHaveRegisteredABuildActionWithTheBootstrapperToRegisterWithIoc()
        {
            context.Config.RegisterBuildAction(c => c.RegisterInstance<SynchronouslyRegisteredTestComponent, SynchronouslyRegisteredTestComponent>());
        }

        [Given(@"I have registered a '(.*)' build action with the bootstrapper to add (.*) to a collection")]
        [Given(@"I have registered an '(.*)' build action with the bootstrapper to add (.*) to a collection")]
        public void GivenIHaveRegisteredABuildActionWithTheBootstrapperToAddToACollection(BuildOrder order, int numberToAddToCollection)
        {
            context.Config.RegisterBuildAction(c => collection.Add(numberToAddToCollection), order);
        }

        [Given(@"I have a bootstrap build component that registers a component with ioc")]
        public void GivenIHaveABootstrapBuildComponentThatRegistersAComponentWithIoc()
        {
        }

        [When(@"I build the bootstrapper")]
        public void WhenIBuildTheBootstrapper()
        {
            context.Config.Initialise();
        }

        [Then(@"I should be able to resolve the registered component from ioc")]
        public void ThenIShouldBeAbleToResolveFromIoc()
        {
            context.Container.ComponentExists<SynchronouslyRegisteredTestComponent>().Should().BeTrue();
        }

        [Then(@"I should be able to resolve the component registered in the bootstrap build component from ioc")]
        public void ThenIShouldBeAbleToResolveTheComponentRegisteredInTheBootstrapBuildComponentFromIoc()
        {
            context.Container.ComponentExists<BootstrapBuildComponentRegisteredTestComponent>().Should().BeTrue();
        }

        [Then(@"the item in position (.*) in the collection should be (.*)")]
        public void ThenTheItemInPositionInTheCollectionShouldBe(int position, int number)
        {
            collection.ElementAt(position).Should().Be(number);
        }

    }
}
