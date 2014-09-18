using System;
using System.Linq;
using SystemDot.Core;

namespace SystemDot.Ioc.ObjectBuilding
{
    public class FromTypeObjectBuilder : IObjectBuilder
    {
        readonly IIocContainer iocContainer;
        readonly Type type;

        public FromTypeObjectBuilder(Type type, IIocContainer iocContainer)
        {
            this.iocContainer = iocContainer;
            this.type = type;
        }

        public object Create()
        {
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