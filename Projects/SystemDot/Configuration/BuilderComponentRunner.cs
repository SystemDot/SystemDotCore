using System;
using SystemDot.Core;
using SystemDot.Core.Collections;
using SystemDot.Environment;
using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public class BuilderComponentRunner
    {
        readonly IIocContainer container;
        readonly ConfigurationBuilder builder;

        public BuilderComponentRunner(IIocContainer container, ConfigurationBuilder builder)
        {
            this.container = container;
            this.builder = builder;
        }

        public void Run()
        {
            GetApplication().GetAllTypes()
                .ThatImplement<IConfigurationBuilderComponent>()
                .ForEach(RunComponent);
        }

        IApplication GetApplication()
        {
            return container.Resolve<IApplication>();
        }

        void RunComponent(Type componentType)
        {
            RunComponent(Activator.CreateInstance(componentType).As<IConfigurationBuilderComponent>());
        }

        void RunComponent(IConfigurationBuilderComponent component)
        {
            component.Configure(builder);
        }
    }
}