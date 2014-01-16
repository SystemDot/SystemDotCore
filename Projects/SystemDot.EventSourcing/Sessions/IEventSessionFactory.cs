namespace SystemDot.EventSourcing.Sessions
{
    public interface IEventSessionFactory
    {
        IEventSession Create();
    }
}