namespace SystemDot.Querying.Mapping
{
    public abstract class ReadModelMapper<T> : IReadModelMapper
    {
        public void Handle(T @event)
        {
            Map(@event);
        }

        protected abstract void Map(T @event);
    }
}