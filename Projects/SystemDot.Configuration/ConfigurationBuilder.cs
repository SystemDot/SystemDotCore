using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public class ConfigurationBuilder
    {
        readonly IIocContainer container;
        readonly List<BuildItem> buildActions;
        
        public ConfigurationBuilder()
            : this(new IocContainer())
        {
        }

        public ConfigurationBuilder(IIocContainer container)
        {
            this.container = container;
            buildActions = new List<BuildItem>();
        }

        public void Build()
        {
            buildActions
                .OrderBy(a => a.Order)
                .ForEach(a => a.ToBuild(container));
        }

        public void RegisterBuildAction(Action<IIocContainer> toBuild, BuildOrder order = BuildOrder.Anywhere)
        {
            buildActions.Add(new BuildItem(toBuild, order));
        }

    }
}