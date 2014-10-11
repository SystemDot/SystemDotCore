using System;
using System.Threading.Tasks;
using SystemDot.Ioc;

namespace SystemDot.Bootstrapping
{
    public class AsyncBuildItem : IBuildItem
    {
        readonly Func<IIocContainer, Task> toBuildAsync;

        public BuildOrder Order { get; private set; }
        
        public void Build(IIocContainer container)
        {
            toBuildAsync(container);
        }

        public async Task BuildAsync(IIocContainer container)
        {
            await toBuildAsync(container);
        }

        public AsyncBuildItem(Func<IIocContainer, Task> toBuild, BuildOrder order)
        {
            toBuildAsync = toBuild;
            Order = order;
        }
    }
}