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
                container.GetAllRegisteredTypes()
                .Select(t => t.ResolveBy));
        }

        public MultipleDecoratorForAssembliesRegistration FromAssemblyOf<T>()
        {
            return new MultipleDecoratorForAssembliesRegistration(
                container,
                container
                    .GetAllRegisteredTypes()
                    .Where(t => t.ActualConcreteType.IsInAssemblyOf<T>())
                    .Select(t => t.ResolveBy));
        }
    }
}