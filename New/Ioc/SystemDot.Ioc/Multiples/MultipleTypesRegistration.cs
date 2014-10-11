namespace SystemDot.Ioc.Multiples
{
    public class MultipleTypesRegistration
    {
        readonly IIocContainer container;

        public MultipleTypesRegistration(IIocContainer container)
        {
            this.container = container;
        }

        public MultpleTypesInAssemblyRegistration<TAssemblyOf> FromAssemblyOf<TAssemblyOf>()
        {
            return new MultpleTypesInAssemblyRegistration<TAssemblyOf>(container);
        }
    }
}