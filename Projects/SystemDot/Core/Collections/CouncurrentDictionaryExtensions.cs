using System;
using System.Collections.Concurrent;

namespace SystemDot.Core.Collections
{
    public static class CouncurrentDictionaryExtensions
    {
        public static bool TryRemove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue temp;
            return dictionary.TryRemove(key, out temp);

        }

        public static void ExecuteIfExists<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key, Action<TValue> toExecute)
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value))
                toExecute(value);
        }
    }
}