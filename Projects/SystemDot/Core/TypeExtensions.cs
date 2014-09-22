using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SystemDot.Core
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> ThatImplement<TType>(this IEnumerable<Type> types)
        {
            return types.WhereNormalConcrete().WhereImplements<TType>();
        }

        public static MethodInfo GetMethod(this Type type, string name, Type[] types)
        {
            return type.GetRuntimeMethod(name, types);
        }

        public static IEnumerable<MethodInfo> GetMethods(this Type type)
        {
            return type.GetRuntimeMethods();
        }

        public static IEnumerable<ConstructorInfo> GetConstructors(this Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors;
        }

        public static IEnumerable<ConstructorInfo> GetAllConstructors(this Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors;
        }

        public static Type[] GetInterfaces(this Type type)
        {
            return type.GetTypeInfo().ImplementedInterfaces.ToArray();
        }

        public static IEnumerable<Type> WhereNormalConcrete(this IEnumerable<Type> types)
        {
            return types.WhereNonAbstract().WhereNonGeneric().WhereConcrete();
        }

        public static IEnumerable<Type> GetNonBaseInterfaces(this Type type)
        {
            IEnumerable<Type> baseInterfaces = GetBaseInterfaces(type);
            return type.GetInterfaces().Where(t => !baseInterfaces.Contains(t));
        }

        public static IEnumerable<Type> GetBaseInterfaces(this Type type)
        {
            var types = new List<Type>();
            Type baseType = type.GetTypeInfo().BaseType;

            if (baseType == typeof(MemberInfo)) return types;

            while (baseType != null)
            {
                types.AddRange(baseType.GetInterfaces());
                baseType = baseType.GetTypeInfo().BaseType;
                if (baseType == typeof(MemberInfo)) return types;
            }
            return types;
        }

        public static Assembly GetAssembly(this Type type)
        {
            return type.GetTypeInfo().Assembly;
        }

        public static IEnumerable<Type> GetTypesInAssembly(this Type type)
        {
            return type.GetTypeInfo().Assembly.ExportedTypes;
        }

        public static IEnumerable<Type> WhereNonAbstract(this IEnumerable<Type> types)
        {
            return types.Where(t => !t.GetTypeInfo().IsAbstract);
        }

        public static IEnumerable<Type> WhereConcrete(this IEnumerable<Type> types)
        {
            return types.Where(t => !t.GetTypeInfo().IsInterface && t.GetTypeInfo().IsClass);
        }

        public static IEnumerable<Type> WhereNonGeneric(this IEnumerable<Type> types)
        {
            return types.Where(t => !t.GetTypeInfo().ContainsGenericParameters);
        }

        public static IEnumerable<Type> WhereImplements<TImplemented>(this IEnumerable<Type> types)
        {
            return types.Where(t =>
                t.GetNonBaseInterfaces().Contains(typeof(TImplemented))
                || t.GetBaseInterfaces().Contains(typeof(TImplemented)));
        }

        public static IEnumerable<Type> WhereImplementsOpenType(this IEnumerable<Type> types, Type openGenericType)
        {
            return types.Where(t => t.GetInterfaces().Any(i => i.IsAssignableFromOpenGenericType(openGenericType)));
        }

        public static bool IsAssignableFromOpenGenericType(this Type type, Type openGenericType)
        {
            return type.GetTypeInfo().IsGenericType && openGenericType.GetTypeInfo().IsAssignableFrom(type.GetGenericTypeDefinition().GetTypeInfo());
        }

        public static IEnumerable<MethodInfo> GetMethodsByName(this Type type, string methodName)
        {
            return type.GetTypeInfo().DeclaredMethods.Where(m => m.Name == methodName);
        }
    }
}