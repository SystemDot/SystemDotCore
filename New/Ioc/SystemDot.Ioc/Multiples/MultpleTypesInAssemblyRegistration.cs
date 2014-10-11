using System;

namespace SystemDot.Ioc.Multiples
{
    public class MultpleTypesInAssemblyRegistration<TAssemblyOf>
    {
        readonly IIocContainer container;

        public MultpleTypesInAssemblyRegistration(IIocContainer container)
        {
            this.container = container;
        }

        public MultpleTypesInAssemblyFilteredRegistration AllTypes()
        {
            return new MultpleTypesInAssemblyFilteredRegistration(container, typeof(TAssemblyOf).GetTypesInAssembly().WhereNormalConcrete());
        }

        public MultpleTypesInAssemblyFilteredRegistration ThatImplementType<T>()
        {
            return new MultpleTypesInAssemblyFilteredRegistration(container, typeof(TAssemblyOf).GetTypesInAssembly().WhereNormalConcrete().WhereImplements<T>());
        }

        public MultpleTypesInAssemblyFilteredRegistration ThatImplementOpenType(Type openType)
        {
            return new MultpleTypesInAssemblyFilteredRegistration(container, typeof(TAssemblyOf).GetTypesInAssembly().WhereNormalConcrete().WhereImplementsOpenType(openType));
        }
    }
}