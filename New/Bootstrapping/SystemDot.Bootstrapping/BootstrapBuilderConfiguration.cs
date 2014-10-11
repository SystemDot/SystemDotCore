using System;
using System.Threading.Tasks;
using SystemDot.Ioc;

namespace SystemDot.Bootstrapping
{
    public class BootstrapBuilderConfiguration
    {
        readonly IIocContainer container;
        readonly BootstrapBuilder builder;
        readonly BootstrapBuilderComponentRunner bootstrapBuilderComponentRunner;

        public BootstrapBuilderConfiguration(IIocContainer container)
        {
            this.container = container;

            builder = new BootstrapBuilder(container);
            bootstrapBuilderComponentRunner = new BootstrapBuilderComponentRunner(container, builder);
        }

        public async Task BaseInitialiseAsync()
        {
            bootstrapBuilderComponentRunner.Run();
            await builder.BuildAsync();
            container.Verify();
        }

        public void BaseInitialise()
        {
            bootstrapBuilderComponentRunner.Run();
            builder.Build();
            container.Verify();
        }

        public BootstrapBuilderConfiguration RegisterBuildAction(Action<IIocContainer> toBuild, BuildOrder order = BuildOrder.Anytime)
        {
            builder.RegisterBuildAction(toBuild, order);
            return this;
        }

        public BootstrapBuilderConfiguration RegisterBuildAction(Func<IIocContainer, Task> toBuild, BuildOrder order = BuildOrder.Anytime)
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