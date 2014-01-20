using System;
using System.Collections.Generic;
using System.Reflection;

namespace SystemDot.Environment
{
    public class Application : IApplication
    {
        public IEnumerable<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }
    }
}
