using System;
using System.Linq;
using SystemDot.Configuration;
using SystemDot.Domain.Configuration;
using SystemDot.EventSourcing.Configuration;
using SystemDot.EventSourcing.InMemory.Configuration;
using SystemDot.Ioc;
using SystemDot.Messaging.Simple;
using SystemDot.Querying;
using SystemDot.Querying.Configuration;
using SystemDot.Querying.Repositories;
using App;
using App.Configuration;
using Domain;
using Domain.Configuration;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            IIocContainer container = new IocContainer();

            Configure.SystemDot()
                .ResolveReferencesWith(container)
                .UseEventSourcing()
                    .DispatchEventUsingSimpleMessaging()
                    .PersistToMemory()
                .UseDomain()
                .UseQuerying()
                .UseTestDomain()
                .UseTestApp()
                .Initialise();

            for (int i = 0; i < 100000; i++)
                Messenger.Send(new ActivateVendor { Name = "VendorMan" + i });

            container.Resolve<IQueryableRepository>()
                .Query<VendorListItem>()
                .ToList()
                .ForEach(i => Console.WriteLine(i.Name));

            Console.WriteLine("Running Test");
            Console.ReadLine();
        }
    }
}
