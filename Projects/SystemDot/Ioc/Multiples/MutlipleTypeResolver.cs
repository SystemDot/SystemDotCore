using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;

namespace SystemDot.Ioc.Multiples
{
    public class MutlipleTypeResolver
    {
        readonly IIocContainer resolver;

        public MutlipleTypeResolver(IIocContainer resolver)
        {
            this.resolver = resolver;
        }

        public IEnumerable<T> ThatImplement<T>()
        {
            return resolver.GetAllRegisteredTypes()
                .ThatImplement<T>()
                .Select(t => resolver.Resolve(t).As<T>());
        }

        public IEnumerable ThatImplementOpenType(Type openType)
        {
            return resolver.GetAllRegisteredTypes()
                .WhereNormalConcrete().WhereImplementsOpenType(openType)
                .Select(t => resolver.Resolve(t));
        }
    }
}