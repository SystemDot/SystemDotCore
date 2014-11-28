using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using SystemDot.Reflection;

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

        public void ByClass(DependencyLifecycle lifecycle)
        {
            foreach (var type in typesToRegister)
            {
                RegisterConcreteByConcrete(type, lifecycle);
            }
        }

        void RegisterConcreteByConcrete(Type type)
        {
            GetRegisterInstanceConcreteByInterface(type, type)
                .Invoke(container, null);
        }
        
        void RegisterConcreteByConcrete(Type type, DependencyLifecycle lifecycle)
        {
            GetRegisterInstanceWithDependencyLifecycleConcreteByInterface(type, type)
                .Invoke(container, new object[] { lifecycle} );
        }

        MethodInfo GetRegisterInstanceConcreteByInterface(Type plugin, Type concrete)
        {
            return GetMethodsByGenericParamentName(GetRegisterInstanceTConcreteMethod(), "TPlugin", "TConcrete")
                .Single(m => !m.GetParameters().Any())
                .MakeGenericMethod(plugin, concrete);
        }

        MethodInfo GetRegisterInstanceWithDependencyLifecycleConcreteByInterface(Type plugin, Type concrete)
        {
            return GetMethodsByGenericParamentName(GetRegisterInstanceTConcreteMethod(), "TPlugin", "TConcrete")
                .Single(MethodHasDependencyLifecycleParameter)
                .MakeGenericMethod(plugin, concrete);
        }

        static bool MethodHasDependencyLifecycleParameter(MethodInfo method)
        {
            return method.GetParameters().Any() 
                && method.GetParameters()[0].ParameterType == typeof(DependencyLifecycle);
        }

        IEnumerable<MethodInfo> GetRegisterInstanceTConcreteMethod()
        {
            return container.GetType().GetMethodsByName(GetRegisterInstanceTConcreteAction(container).GetMethodInfo().Name);
        }

        static Action GetRegisterInstanceTConcreteAction(IIocContainer iocContainer)
        {
            return iocContainer.RegisterInstance<object, object>;
        }

        static IEnumerable<MethodInfo> GetMethodsByGenericParamentName(IEnumerable<MethodInfo> methods, params string[] names)
        {
            return methods
                .Where(m => m.GetGenericArguments()
                    .All(a => names.Contains(a.Name)) && m.GetGenericArguments().Count() == names.Count());
        }
    }
}