using System;
using System.Reflection;
using SystemDot.Core;

namespace SystemDot.Messaging.Handling
{
    static class TypeExtensions
    {
        public static MethodInfo GetHandleMethodForMessage(this Type type, object message)
        {
            return type.GetMethod("Handle", GetMessageType(message));

        }

        static Type[] GetMessageType(object message)
        {
            return new[] { message.GetType() };
        }
    }
}