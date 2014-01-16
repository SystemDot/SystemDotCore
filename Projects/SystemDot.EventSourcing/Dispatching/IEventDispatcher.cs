namespace SystemDot.EventSourcing.Dispatching
{
    public interface IEventDispatcher
    {
        void Dispatch(object toDispatch);
    }
}