using SystemDot.Querying;

namespace App
{
    public class VendorListItem : IdEqualityBase<VendorListItem>
    {
        public string Name { get; set; }
    }
}