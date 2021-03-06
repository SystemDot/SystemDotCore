﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SystemDot.Environment
{
    public class Application : IApplication
    {
        public IEnumerable<Type> GetAllTypes()
        {
            return GetAssemblies().SelectMany(GetTypes);
                
        }

        IEnumerable<Type> GetTypes(Assembly assembly)
        {
            try
            {
                return assembly.ExportedTypes;
            }
            catch (NotSupportedException)
            {
                return new List<Type>();
            }
        }

        IEnumerable<Assembly> GetAssemblies()
        {
            return AppDomain.CurrentDomain.GetAssemblies();
        }
    }
}
