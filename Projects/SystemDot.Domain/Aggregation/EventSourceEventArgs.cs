using System;

namespace SystemDot.Domain.Aggregation
{
    public class EventSourceEventArgs : EventArgs
    {
        public object Event { get; private set; }

        public EventSourceEventArgs(object @event)
        {
            Event = @event;
        }
    }
}