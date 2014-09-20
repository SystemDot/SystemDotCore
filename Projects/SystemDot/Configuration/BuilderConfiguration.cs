using System;
using System.Threading.Tasks;
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

        public async Task BaseInitialiseAsync()
        {
            builderComponentRunner.Run();
            await builder.BuildAsync();
        }

        public void RegisterBuildAction(Action<IIocContainer> toBuild, BuildOrder order = BuildOrder.Anytime)
        {
            builder.RegisterBuildAction(toBuild, order);
        }

        public void RegisterBuildAction(Func<IIocContainer, Task> toBuild, BuildOrder order = BuildOrder.Anytime)
        {
            builder.RegisterBuildAction(toBuild, order);
        }

        public IIocContainer GetIocContainer()
        {
            return externalContainer;
        }
    }
}