using System.Reflection;
using System.Threading.Tasks;
using SystemDot.Core;

namespace SystemDot.Messaging.Handling
{
    static class ObjectExtensions
    {
        public static object InvokeHandler(this object handler, object message)
        {
            MethodInfo method = GetHandlerMethodInfo(handler, message);

            return method == null 
                ? null 
                : method.Invoke(handler, new[] { message });
        }

        public async static Task InvokeHandlerAsync(this object handler, object message)
        {        
            MethodInfo method = GetHandlerMethodInfo(handler, message);
            if (method == null) return;

            await method
                .Invoke(handler, new[] { message })
                .As<Task>();
        }

        static MethodInfo GetHandlerMethodInfo(this object handler, object message)
        {
            return handler.GetType().GetHandleMethodForMessage(message);
        }
    }
}