namespace SystemDot.Messaging.Handling.Actions
{
    internal interface IPerMessageActionHandlerList
    {
        void RouteMessageToHandlers(object message);
        PerMessageActionHandlerList<T> ForMessage<T>();
    }
}