using System;
using SystemDot.Core.Collections;
using SystemDot.Ioc;
using SystemDot.Messaging.Simple;

namespace SystemDot.Messaging.Handling.Configuration
{
    public static class IocConfigurationExtensions
    {
        public static void RegisterOpenTypeHandlersWithMessenger(
            this IIocContainer container, 
            Type openType)
        {
            container.ResolveMutipleTypes()
                .ThatImplementOpenType(openType)
                .ForEach(Messenger.RegisterHandler);
        }
    }
}