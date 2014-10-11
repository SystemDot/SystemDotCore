using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SystemDot.Ioc;

namespace SystemDot.Bootstrapping
{
    public class BootstrapBuilder
    {
        readonly IIocContainer container;
        readonly List<IBuildItem> buildActions;
        
        public BootstrapBuilder(IIocContainer container)
        {
            this.container = container;
            buildActions = new List<IBuildItem>();
        }

        public async Task BuildAsync()
        {
            foreach (var action in buildActions.OrderBy(a => a.Order))
            {
                 await action.BuildAsync(container);
            }  
        }

        public void Build()
        {
            foreach (var action in buildActions.OrderBy(a => a.Order))
            {
                action.Build(container);
            }
        }

        public void RegisterBuildAction(Action<IIocContainer> toBuild, BuildOrder order = BuildOrder.Anytime)
        {
            buildActions.Add(new BuildItem(toBuild, order));
        }

        public void RegisterBuildAction(Func<IIocContainer, Task> toBuild, BuildOrder order = BuildOrder.Anytime)
        {
            buildActions.Add(new AsyncBuildItem(toBuild, order));
        }
    }
}