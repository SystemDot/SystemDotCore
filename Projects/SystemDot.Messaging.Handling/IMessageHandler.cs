namespace SystemDot.Messaging.Handling
{
    public interface IMessageHandler
    {
    }

    public interface IMessageHandler<in T> : IMessageHandler
    {
        void Handle(T message);
    }
}