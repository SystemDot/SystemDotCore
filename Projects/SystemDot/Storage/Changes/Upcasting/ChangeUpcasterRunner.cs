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
            return application.GetAllTypes().ThatImplement<IChangeUpcaster>();
        }

        public Change UpcastIfRequired(Change toUpcast)
        {
            if (toUpcast.Version == Change.LatestVersion) return toUpcast;
            if (!UpcasterExistsFor(toUpcast)) return toUpcast;

            return GetUpcaster(toUpcast).Upcast(toUpcast);
        }

        bool UpcasterExistsFor(Change toUpcast)
        {
            return upcasters.Any(u => u.ChangeType == toUpcast.GetType() && u.Version >= toUpcast.Version);
        }

        IChangeUpcaster GetUpcaster(Change toUpcast)
        {
            return upcasters.Single(u => u.ChangeType == toUpcast.GetType());
        }
    }
}