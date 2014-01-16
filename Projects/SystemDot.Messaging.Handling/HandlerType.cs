using System;
using SystemDot.Ioc;

namespace SystemDot.Messaging.Simple
{
    class HandlerType
    {
        public Type Type { get; private set; }

        public IIocResolver Resolver { get; private set; }

        public HandlerType(Type handlerType, IIocResolver resolver)
        {
            Type = handlerType;
            Resolver = resolver;
        }
    }
}