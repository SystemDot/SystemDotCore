using System;
using SystemDot.Domain.Commands;
using SystemDot.EventSourcing.Sessions;

namespace Domain
{
    public class ActivateVendorCommandHandler : ICommandHandler<ActivateVendor>
    {
        readonly IEventSessionFactory eventSessionFactory;

        public ActivateVendorCommandHandler(IEventSessionFactory eventSessionFactory)
        {
            this.eventSessionFactory = eventSessionFactory;
        }

        public void Handle(ActivateVendor command)
        {
            using (var session = eventSessionFactory.Create())
            {
                var v = new Vendor(Guid.NewGuid());
                v.Activate(command.Name);

                session.Commit(Guid.NewGuid());
            }
        }
    }
}