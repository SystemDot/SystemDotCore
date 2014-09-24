using System.Linq;

namespace SystemDot.Ioc.Multiples
{
    public class MultipleDecoratorRegistration
    {
        readonly IIocContainer container;

        public MultipleDecoratorRegistration(IIocContainer container)
        {
            this.container = container;
        }

        public MultipleDecoratorForAssembliesRegistration FromAllAssemblies()
        {
            return new MultipleDecoratorForAssembliesRegistration(
                container,
                container.GetAllRegisteredTypes().Select(t => t.ActualConcreteType));
        }

        public MultipleDecoratorForAssembliesRegistration FromAssemblyOf<T>()
        {
            return new MultipleDecoratorForAssembliesRegistration(
                container, 
                container
                    .GetAllRegisteredTypes()
                    .Select(t => t.ActualConcreteType)
                    .WhereInAssemblyOf<T>());
        }
    }
}