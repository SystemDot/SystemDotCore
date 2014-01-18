using System.Reflection;

namespace SystemDot.Messaging.Handling
{
    static class ObjectExtensions
    {
        public static void Invoke(this object handler, object message)
        {
            MethodInfo method = GetHandlerMethodInfo(handler, message);
            if (method == null) return;

            method.Invoke(handler, new[] { message });
        }

        static MethodInfo GetHandlerMethodInfo(this object handler, object message)
        {
            return handler.GetType().GetHandleMethodForMessage(message);
        }
    }
}