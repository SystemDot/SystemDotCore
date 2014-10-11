using System;
using System.Linq;

namespace SystemDot.Ioc.ObjectBuilding
{
    public class FromTypeObjectBuilder : ObjectBuilder
    {
        readonly IIocContainer iocContainer;
        readonly Type type;

        public FromTypeObjectBuilder(Type type, IIocContainer iocContainer)
            : base(iocContainer)
        {
            this.iocContainer = iocContainer;
            this.type = type;
        }

        public override object Create()
        {
            var constructorInfo = type
                .GetAllConstructors()
                .First();

            var parameters = constructorInfo.GetParameters();

            var parameterInstances = new object[parameters.Count()];

            for (var i = 0; i < parameters.Count(); i++)
                parameterInstances[i] = ResolveParameter(parameters[i].ParameterType);

            return constructorInfo.Invoke(parameterInstances);
        }

        public override Type GetInnerMostType()
        {
            return type;
        }

        protected virtual object ResolveParameter(Type parameterType)
        {
            return iocContainer.Resolve(parameterType);
        }

        public override string ToString()
        {
            return type.Name;
        }
    }
}