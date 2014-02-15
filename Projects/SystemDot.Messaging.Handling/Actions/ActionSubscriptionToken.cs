using SystemDot.Core;

namespace SystemDot.Messaging.Handling.Actions
{
    public class ActionSubscriptionToken : Disposable
    {
        public object Handler { get; private set; }

        public ActionSubscriptionToken(object handler)
        {
            Handler = handler;
        }

        protected override void DisposeOfManagedResources()
        {
            Handler = null;
            base.DisposeOfManagedResources();
        }
    }
}