namespace SystemDot.Messaging
{
    public interface IBus
    {
        void PublishEvent(object toPublish);
        void Send(object toSend);
    }
}