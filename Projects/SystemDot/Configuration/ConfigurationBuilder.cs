using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemDot.Core.Collections;
using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public class ConfigurationBuilder
    {
        readonly IIocContainer container;
        readonly List<BuildItem> buildActions;
        
        public ConfigurationBuilder(IIocContainer container)
        {
            this.container = container;
            buildActions = new List<BuildItem>();
        }

        public async Task BuildAsync()
        {
            foreach (var action in buildActions.OrderBy(a => a.Order))
            {
                 await action.ToBuild(container);
            }  
        }

        public void RegisterBuildAction(Action<IIocContainer> toBuild, BuildOrder order = BuildOrder.Anytime)
        {
            buildActions.Add(new BuildItem(toBuild, order));
        }

        public void RegisterBuildAction(Func<IIocContainer, Task> toBuild, BuildOrder order = BuildOrder.Anytime)
        {
            buildActions.Add(new BuildItem(toBuild, order));
        }
    }
}