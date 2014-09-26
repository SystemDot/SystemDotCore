using System;
using System.Threading.Tasks;
using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public class BuilderConfiguration
    {
        readonly IIocContainer container;
        readonly ConfigurationBuilder builder;
        readonly BuilderComponentRunner builderComponentRunner;

        public BuilderConfiguration(IIocContainer container)
        {
            this.container = container;

            builder = new ConfigurationBuilder(container);
            builderComponentRunner = new BuilderComponentRunner(container, builder);
        }

        public async Task BaseInitialiseAsync()
        {
            builderComponentRunner.Run();
            await builder.BuildAsync();
            container.Verify();
        }

        public BuilderConfiguration RegisterBuildAction(Action<IIocContainer> toBuild, BuildOrder order = BuildOrder.Anytime)
        {
            builder.RegisterBuildAction(toBuild, order);
            return this;
        }

        public BuilderConfiguration RegisterBuildAction(Func<IIocContainer, Task> toBuild, BuildOrder order = BuildOrder.Anytime)
        {
            builder.RegisterBuildAction(toBuild, order);
            return this;
        }

        public IIocContainer GetIocContainer()
        {
            return container;
        }
    }
}