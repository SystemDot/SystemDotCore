using System;
using System.Collections.Generic;

namespace SystemDot.Bootstrapping
{
    internal static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> toEnumerate, Action<T> toPerform)
        {
            foreach (var item in toEnumerate)
            {
                toPerform(item);
            }
        }
    }
}