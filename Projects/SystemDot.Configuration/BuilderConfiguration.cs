using System;
using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public class BuilderConfiguration : IBuilderConfiguration
    {
        readonly ConfigurationBuilder builder;

        public BuilderConfiguration(IIocContainer externalContainer)
        {
            builder = new ConfigurationBuilder(externalContainer);
        }
        
        public void Initialise()
        {
            builder.Build();
        }

        public void RegisterBuildAction(Action<IIocContainer> toBuild, BuildOrder order = BuildOrder.Anywhere)
        {
            builder.RegisterBuildAction(toBuild, order);
        }
    }
}