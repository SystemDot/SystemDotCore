using SystemDot.Querying;
using SystemDot.Querying.Mapping;
using SystemDot.Querying.Repositories;
using Domain;

namespace App
{
    public class VendorListMapper : ReadModelMapper<VendorActivated>
    {
        readonly IQueryableRepository repository;

        public VendorListMapper(IQueryableRepository repository)
        {
            this.repository = repository;
        }

        protected override void Map(VendorActivated @event)
        {
            repository.Add(new VendorListItem { Id = @event.VendorId, Name = @event.VendorName});
        }
    }
}
