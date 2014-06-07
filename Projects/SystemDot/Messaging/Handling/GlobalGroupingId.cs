using SystemDot.Core;

namespace SystemDot.Messaging.Handling
{
    public class GlobalGroupingId : Equatable<GlobalGroupingId>
    {
        static readonly GlobalGroupingId DefaultInstance = new GlobalGroupingId();

        public static GlobalGroupingId Default
        {
            get { return DefaultInstance; }
        }

        public override bool Equals(GlobalGroupingId other)
        {
            return true;
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}