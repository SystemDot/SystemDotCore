using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SystemDot.Ioc.Multiples
{
    internal static class TypeExtensions
    {
        public static IEnumerable<Type> GetTypesInAssembly(this Type type)
        {
            return type.GetTypeInfo().Assembly.ExportedTypes;
        }

        public static IEnumerable<Type> WhereImplementsOpenType(this IEnumerable<Type> types, Type openGenericType)
        {
            return types.Where(t => t.ImplementsOpenType(openGenericType));
        }

        static bool ImplementsOpenType(this Type type, Type openGenericType)
        {
            return type.IsAssignableFromOpenGenericType(openGenericType)
                || (type.GetTypeInfo().BaseType != null && type.GetTypeInfo().BaseType.IsAssignableFromOpenGenericType(openGenericType))
                || type.GetInterfaces().Any(i => i.IsAssignableFromOpenGenericType(openGenericType));
        }

        public static IEnumerable<MethodInfo> GetMethodsByName(this Type type, string methodName)
        {
            return type.GetTypeInfo().DeclaredMethods.Where(m => m.Name == methodName);
        }

        public static bool IsInAssemblyOf<T>(this Type type)
        {
            return type.GetAssembly().FullName == typeof(T).GetAssembly().FullName;
        }
    }
}