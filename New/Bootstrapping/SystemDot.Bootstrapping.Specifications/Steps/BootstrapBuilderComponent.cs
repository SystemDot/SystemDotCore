namespace SystemDot.Bootstrapping.Specifications.Steps
{
    public class BootstrapBuilderComponent : IBootstrapBuilderComponent
    {
        public void Configure(BootstrapBuilder builder)
        {
            builder.RegisterBuildAction(c => c.RegisterInstance<BootstrapBuildComponentRegisteredTestComponent, BootstrapBuildComponentRegisteredTestComponent>());
        }
    }
}