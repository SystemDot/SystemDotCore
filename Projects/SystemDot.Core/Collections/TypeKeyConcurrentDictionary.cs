using System;
using System.Collections.Concurrent;

namespace SystemDot.Core.Collections
{
    public class TypeKeyConcurrentDictionary<TValue> : ConcurrentDictionary<Type, TValue>
    {
        public bool ContainsKey<T>()
        {
            return ContainsKey(typeof (T));
        }

        public bool TryAdd<T>(TValue value)
        {
            return TryAdd(typeof(T), value);
        }

        public void Remove<T>()
        {
            this.TryRemove(typeof(T));
        }

        public bool TryGetValue<T>(out TValue value)
        {
            return TryGetValue(typeof(T), out value);
        }

        public void ExecuteIfExists<T>(Action<TValue> toExecute)
        {
            this.ExecuteIfExists(typeof (T), toExecute);
        }
    }
}