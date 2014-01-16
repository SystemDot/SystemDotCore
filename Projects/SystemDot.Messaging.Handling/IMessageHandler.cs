namespace SystemDot.Messaging.Simple
{
    public interface IMessageHandler
    {
    }

    public interface IMessageHandler<in T> : IMessageHandler
    {
        void Handle(T message);
    }
}