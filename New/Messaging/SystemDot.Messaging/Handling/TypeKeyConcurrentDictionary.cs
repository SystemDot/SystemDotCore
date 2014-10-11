using System;
using System.Collections.Concurrent;

namespace SystemDot.Messaging.Handling
{
    public class TypeKeyConcurrentDictionary<TValue> : ConcurrentDictionary<Type, TValue>
    {
        public bool ContainsKey<T>()
        {
            return ContainsKey(typeof(T));
        }

        public bool TryAdd<T>(TValue value)
        {
            return TryAdd(typeof(T), value);
        }

        public void ExecuteIfExists<T>(Action<TValue> toExecute)
        {
            this.ExecuteIfExists(typeof(T), toExecute);
        }
    }
}