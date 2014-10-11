namespace SystemDot.Messaging.Handling.Actions
{
    internal interface IPerMessageActionHandlerList
    {
        void RouteMessageToHandlers(object message, object groupingId);
        PerMessageActionHandlerList<T> ForMessage<T>();
    }
}