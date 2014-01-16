using System;
using System.Collections.Generic;
using System.Linq;
using SystemDot.Core;
using SystemDot.Environment;

namespace SystemDot.Storage.Changes.Upcasting
{
    public class ChangeUpcasterRunner
    {
        readonly IApplication application;
        readonly IList<IChangeUpcaster> upcasters;

        public ChangeUpcasterRunner(IApplication application)
        {
            this.application = application;
            upcasters = GetUpcasters();
        }

        IList<IChangeUpcaster> GetUpcasters()
        {
            return GetUpcasterTypes()
                .Select(Activator.CreateInstance)
                .Cast<IChangeUpcaster>()
                .ToList();
        }

        IEnumerable<Type> GetUpcasterTypes()
        {
            return application.GetAssemblies()
                .SelectMany(a => a.GetTypesThatImplement<IChangeUpcaster>())
                .ToList();
        }

        public Change UpcastIfRequired(Change toUpcast)
        {
            if (toUpcast.Version == Change.LatestVersion) return toUpcast;
            if (!UpcasterExistsFor(toUpcast, toUpcast.Version)) return toUpcast;

            return GetUpcaster(toUpcast).Upcast(toUpcast);
        }

        bool UpcasterExistsFor(Change toUpcast, int version)
        {
            return upcasters.Any(u => u.ChangeType == toUpcast.GetType() && u.Version == version);
        }

        IChangeUpcaster GetUpcaster(Change toUpcast)
        {
            return upcasters.Single(u => u.ChangeType == toUpcast.GetType());
        }
    }
}