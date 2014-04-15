namespace SystemDot.Messaging
{
    public interface IBus
    {
        void Publish(object toPublish);
        void Send(object toSend);
    }
}