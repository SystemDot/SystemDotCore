using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;

namespace SystemDot.Ioc
{
    public class ConcreteInstance
    {
        readonly IocContainer iocContainer;
        readonly List<Type> decorators;
        readonly Type objectType;
        readonly Func<object> objectFactory;
        object objectInstance;

        public static T Create<T>(IocContainer iocContainer)
        {
            return new ConcreteInstance(typeof (T), iocContainer).Resolve().As<T>();
        }

        public ConcreteInstance(Type objectType, IocContainer iocContainer)
        {
            this.iocContainer = iocContainer;
            decorators = new List<Type>();
            this.objectType = objectType;
        }

        public ConcreteInstance(Func<object> objectFactory, IocContainer iocContainer)
        {
            this.iocContainer = iocContainer;
            decorators = new List<Type>();
            this.objectFactory = objectFactory;
        }

        void SetObjectInstance(object instance)
        {
            objectInstance = instance;
        }

        public void DecorateWith<T>()
        {
            decorators.Add(typeof(T));
        }

        public object Resolve()
        {
            if (objectInstance == null)
                SetObjectInstance(objectFactory != null ? objectFactory.Invoke() : Create(objectType));

            return objectInstance;
        }

        object Create(Type type)
        {
            if (decorators.Any()) return Create(decorators.Single());
            
            var constructorInfo = type
                .GetAllConstructors()
                .First();

            var parameters = constructorInfo.GetParameters();

            var parameterInstances = new object[parameters.Count()];

            for (var i = 0; i < parameters.Count(); i++)
                parameterInstances[i] = iocContainer.Resolve(parameters[i].ParameterType);

            return constructorInfo.Invoke(parameterInstances);
        }
    }
}