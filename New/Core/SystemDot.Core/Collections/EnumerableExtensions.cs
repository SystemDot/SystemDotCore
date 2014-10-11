using System;
using System.Collections;
using System.Collections.Generic;

namespace SystemDot.Core.Collections
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> toEnumerate, Action<T> toPerform)
        {
            foreach (var item in toEnumerate)
            {
                toPerform(item);
            }
        }

        public static void ForEach(this IEnumerable toEnumerate, Action<object> toPerform)
        {
            foreach (var item in toEnumerate)
            {
                toPerform(item);
            }
        }
    }
}