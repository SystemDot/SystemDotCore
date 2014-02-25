using System;
using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public class BuildItem
    {
        public Action<IIocContainer> ToBuild { get; set; }
        public BuildOrder Order { get; set; }

        public BuildItem(Action<IIocContainer> toBuild, BuildOrder order)
        {
            ToBuild = toBuild;
            Order = order;
        }
    }
}