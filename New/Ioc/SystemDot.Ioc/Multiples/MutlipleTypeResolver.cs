using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace SystemDot.Ioc.Multiples
{
    public class MutlipleTypeResolver
    {
        readonly IIocContainer container;

        public MutlipleTypeResolver(IIocContainer container)
        {
            this.container = container;
        }

        public IEnumerable<T> ThatImplement<T>()
        {
            return container.GetAllRegisteredTypes()
                .Select(t => t.ResolveBy)
                .ThatImplement<T>()
                .Select(t => container.Resolve(t).As<T>());
        }

        public IEnumerable ThatImplementOpenType(Type openType)
        {
            return container.GetAllRegisteredTypes()
                .Select(t => t.ResolveBy)
                .WhereImplementsOpenType(openType)
                .Select(t => container.Resolve(t));
        }
    }
}