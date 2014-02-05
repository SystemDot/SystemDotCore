using System;
using MonoTouch.UIKit;

namespace SystemDot.ThreadMarshalling
{
    public class MainThreadMarshaller : IMainThreadMarshaller
    {
        public void RunOnMainThread(Action toRun)
        {
            UIApplication.SharedApplication.InvokeOnMainThread(() => toRun());
        }
    }
}
