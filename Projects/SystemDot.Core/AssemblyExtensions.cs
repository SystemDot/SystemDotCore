using System;
using System.Collections.Generic;
using System.Reflection;

namespace SystemDot.Core
{
    public static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetTypesThatImplement<TType>(this Assembly assembly)
        {
            return assembly.ExportedTypes.WhereNormalConcrete().WhereImplements<TType>();
        }
    }
}