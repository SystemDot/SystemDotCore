using System;
using System.Threading.Tasks;
using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public class BuildItem
    {
        public Func<IIocContainer, Task> ToBuild { get; private set; }
        public BuildOrder Order { get; private set; }

        public BuildItem(Func<IIocContainer, Task> toBuild, BuildOrder order)
        {
            ToBuild = toBuild;
            Order = order;
        }

        public BuildItem(Action<IIocContainer> toBuild, BuildOrder order)
        {
            ToBuild = c => 
            { 
                toBuild(c); 
                return Task.FromResult(false);
            };
            Order = order;
        }
    }
}