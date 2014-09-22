using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SystemDot.Core;
using SystemDot.Ioc.Multiples;

namespace SystemDot.Ioc
{
    internal static class TypeExtensions
    {
        public static IEnumerable<ConstructorInfo> GetAllConstructors(this Type type)
        {
            return type.GetTypeInfo().DeclaredConstructors;
        }

        public static Type MakeGenericTypeFrom(this Type type, Type toMakeFrom)
        {
            return type.MakeGenericType(type.FindMatchingOpenTypeInHeritage(toMakeFrom).GenericTypeArguments);
        }

        static Type FindMatchingOpenTypeInHeritage(this Type type, Type toSearch)
        {
            foreach (var openGenericInterface in type.GetInterfaces())
                if (openGenericInterface.SharesSameGenericTypeDefinitionAs(toSearch))
                    return toSearch;

            foreach (var openGenericInterface in type.GetInterfaces())
                foreach (var toSearchInterface in toSearch.GetInterfaces())
                    if (openGenericInterface.SharesSameGenericTypeDefinitionAs(toSearchInterface)) 
                        return toSearchInterface;
            return null;
        }

        static bool SharesSameGenericTypeDefinitionAs(this Type type, Type toSearch)
        {
            if(!type.GetTypeInfo().IsGenericType) return false;
            if(!toSearch.GetTypeInfo().IsGenericType) return false;
            return type.GetGenericTypeDefinition() == toSearch.GetGenericTypeDefinition();
        }

        public static bool IsAssignableFromOpenGenericType(this Type type, Type openGenericType)
        {
            return type.GetTypeInfo().IsGenericType 
                && openGenericType.GetTypeInfo().IsAssignableFrom(type.GetGenericTypeDefinition().GetTypeInfo());
        }
    }
}