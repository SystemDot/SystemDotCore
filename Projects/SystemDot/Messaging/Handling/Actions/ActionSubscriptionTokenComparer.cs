using System.Collections.Generic;

namespace SystemDot.Messaging.Handling.Actions
{
    // required because of AOT problems with iOS
    public class ActionSubscriptionTokenComparer : IEqualityComparer<IActionSubscriptionToken>
    {
        public bool Equals(IActionSubscriptionToken x, IActionSubscriptionToken y)
        {
            return x == y;
        }

        public int GetHashCode(IActionSubscriptionToken obj)
        {
            return obj == null ? 0 : obj.GetHashCode();
        }
    }
}