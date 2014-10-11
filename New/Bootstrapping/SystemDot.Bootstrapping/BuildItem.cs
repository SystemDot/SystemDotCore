using System;
using System.Threading.Tasks;
using SystemDot.Ioc;

namespace SystemDot.Bootstrapping
{
    public class BuildItem : IBuildItem
    {
        readonly Action<IIocContainer> toBuild;

        public BuildOrder Order { get; private set; }

        public void Build(IIocContainer container)
        {
            toBuild(container);
        }

        public async Task BuildAsync(IIocContainer container)
        {
            toBuild(container);
            await Task.FromResult(false);
        }

        public BuildItem(Action<IIocContainer> toBuild, BuildOrder order)
        {
            this.toBuild = toBuild;
            Order = order;
        }
    }
}