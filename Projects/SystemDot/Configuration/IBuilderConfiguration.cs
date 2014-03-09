using System;
using SystemDot.Ioc;

namespace SystemDot.Configuration
{
    public interface IBuilderConfiguration
    {
        void Initialise();

        void RegisterBuildAction(Action<IIocContainer> toBuild, BuildOrder order = BuildOrder.Anytime);
    }
}