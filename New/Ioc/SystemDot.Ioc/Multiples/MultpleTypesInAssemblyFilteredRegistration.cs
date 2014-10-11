using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SystemDot.Ioc.Multiples
{
    public class MultpleTypesInAssemblyFilteredRegistration
    {
        readonly IIocContainer container;
        readonly IEnumerable<Type> typesToRegister;

        public MultpleTypesInAssemblyFilteredRegistration(IIocContainer container, IEnumerable<Type> typesToRegister)
        {
            this.typesToRegister = typesToRegister;
            this.container = container;
        }

        public void ByClassAndInterface()
        {
            foreach (var type in typesToRegister)
            {
                RegisterConcreteByConcrete(type);
                RegisterConcreteByInterfaceIfPossible(type);
            }
        }

        public void ByInterface()
        {
            foreach (var type in typesToRegister)
            {
                RegisterConcreteByInterfaceIfPossible(type);
            }
        }

        void RegisterConcreteByInterfaceIfPossible(Type type)
        {
            if (type.GetNonBaseInterfaces().Any()) RegisterConcreteByInterface(type);
        }

        void RegisterConcreteByInterface(Type type)
        {
            GetRegisterInstanceConcreteByInterface(type.GetNonBaseInterfaces().First(), type)
                .Invoke(container, null);
        }

        public void ByClass()
        {
            foreach (var type in typesToRegister)
            {
                RegisterConcreteByConcrete(type);
            }
        }

        void RegisterConcreteByConcrete(Type type)
        {
            GetRegisterInstanceConcreteByInterface(type, type)
                .Invoke(container, null);
        }

        MethodInfo GetRegisterInstanceConcreteByInterface(Type plugin, Type concrete)
        {
            return GetMethodByGenericParamentName(GetRegisterInstanceTConcreteMethod(), "TPlugin", "TConcrete")
                .MakeGenericMethod(plugin, concrete);
        }

        IEnumerable<MethodInfo> GetRegisterInstanceTConcreteMethod()
        {
            return container.GetType().GetMethodsByName(GetRegisterInstanceTConcreteAction(container).GetMethodInfo().Name);
        }

        static Action GetRegisterInstanceTConcreteAction(IIocContainer iocContainer)
        {
            return iocContainer.RegisterInstance<object, object>;
        }

        static MethodInfo GetMethodByGenericParamentName(IEnumerable<MethodInfo> methods, params string[] names)
        {
            return methods
                .Single(m => m.GetGenericArguments()
                    .All(a => names.Contains(a.Name)) && m.GetGenericArguments().Count() == names.Count());
        }
    }
}