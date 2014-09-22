using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SystemDot.Core
{
    public static class TypeExtensions
    {
        public static Assembly GetAssembly(this Type type)
        {
            return type.GetTypeInfo().Assembly;
        }

        public static IEnumerable<Type> ThatImplement<TType>(this IEnumerable<Type> types)
        {
            return types.WhereNormalConcrete().WhereImplements<TType>();
        }

        public static IEnumerable<Type> WhereImplements<TImplemented>(this IEnumerable<Type> types)
        {
            return types.Where(t =>
                t.GetNonBaseInterfaces().Contains(typeof(TImplemented))
                || t.GetBaseInterfaces().Contains(typeof(TImplemented)));
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

        public static Type[] GetInterfaces(this Type type)
        {
            return type.GetTypeInfo().ImplementedInterfaces.ToArray();
        }
        public static IEnumerable<Type> WhereNormalConcrete(this IEnumerable<Type> types)
        {
            return types.WhereNonAbstract().WhereNonGeneric().WhereConcrete();
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

        public static IEnumerable<MethodInfo> GetMethods(this Type type)
        {
            return type.GetRuntimeMethods();
        }

        public static MethodInfo GetMethod(this Type type, string methodName, Type[] args)
        {
            return type.GetRuntimeMethod(methodName, args);
        }

        public static IEnumerable<ConstructorInfo> GetConstructors(this Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors;
        }
    }
}