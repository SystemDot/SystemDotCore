using System.Threading.Tasks;

namespace SystemDot.Messaging.Handling.Actions.Async
{
    internal interface IAsyncPerMessageActionHandlerList
    {
        Task RouteMessageToHandlers(object message, object groupingId);
        AsyncPerMessageActionHandlerList<T> ForMessage<T>();
    }
}