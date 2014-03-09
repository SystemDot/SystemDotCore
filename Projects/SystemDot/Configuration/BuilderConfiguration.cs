using System;
using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public class BuilderConfiguration
    {
        readonly IIocContainer externalContainer;
        readonly ConfigurationBuilder builder;
        readonly BuilderComponentRunner builderComponentRunner;

        public BuilderConfiguration(IIocContainer externalContainer)
        {
            this.externalContainer = externalContainer;

            builder = new ConfigurationBuilder(externalContainer);
            builderComponentRunner = new BuilderComponentRunner(externalContainer, builder);
        }

        public void BaseInitialise()
        {
            builderComponentRunner.Run();
            builder.Build();
        }

        public void RegisterBuildAction(Action<IIocContainer> toBuild, BuildOrder order = BuildOrder.Anytime)
        {
            builder.RegisterBuildAction(toBuild, order);
        }

        public IIocContainer GetIocContainer()
        {
            return externalContainer;
        }
    }
}