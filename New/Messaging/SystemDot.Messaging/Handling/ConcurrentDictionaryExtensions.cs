using System;
using System.Collections.Concurrent;
using System.Threading.Tasks;

namespace SystemDot.Messaging.Handling
{
    public static class ConcurrentDictionaryExtensions
    {
        public static void ExecuteIfExists<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key, Action<TValue> toExecute)
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value))
                toExecute(value);
        }

        public static async Task ExecuteIfExistsAsync<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key, Func<TValue, Task> toExecute)
        {
            TValue value;
            if (dictionary.TryGetValue(key, out value))
                await toExecute(value);
        }
    }
}