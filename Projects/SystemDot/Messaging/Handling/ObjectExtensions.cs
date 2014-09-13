using System.Reflection;
using System.Threading.Tasks;
using SystemDot.Core;

namespace SystemDot.Messaging.Handling
{
    static class ObjectExtensions
    {
        public static void InvokeHandler(this object handler, object message)
        {
            MethodInfo method = GetHandlerMethodInfo(handler, message);
            if (method == null) return;

            method.Invoke(handler, new[] { message });
        }

        public async static Task InvokeHandlerAsync(this object handler, object message)
        {        
            MethodInfo method = GetHandlerMethodInfo(handler, message);
            if (method == null) return;

            await method.Invoke(handler, new[] { message }).As<Task>();
            method.Invoke(handler, new[] { message });
        }

        static MethodInfo GetHandlerMethodInfo(this object handler, object message)
        {
            return handler.GetType().GetHandleMethodForMessage(message);
        }
    }
}