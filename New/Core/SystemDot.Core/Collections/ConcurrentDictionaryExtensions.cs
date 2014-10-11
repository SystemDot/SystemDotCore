using System.Collections.Concurrent;

namespace SystemDot.Core.Collections
{
    public static class ConcurrentDictionaryExtensions
    {
        public static bool TryRemove<TKey, TValue>(this ConcurrentDictionary<TKey, TValue> dictionary, TKey key)
        {
            TValue temp;
            return dictionary.TryRemove(key, out temp);
        }
    }
}