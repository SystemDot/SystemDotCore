using System;
using System.Collections.Generic;

namespace SystemDot.Ioc
{
    internal static class ObjectExtensions
    {
        public static T As<T>(this object toCast)
        {
            return (T)toCast;
        }
    }

    internal static class IEnumerableExtensions
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