using System;
using System.Reflection;
using SystemDot.Core;

namespace SystemDot.Messaging.Simple
{
    static class TypeExtensions
    {
        public static MethodInfo GetHandleMethodForMessage(this Type type, object message)
        {
            return type.GetMethod("Handle", new[] { message.GetType() });
        }
    }
}