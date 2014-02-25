using System;

namespace SystemDot.ThreadMarshalling
{
    public class MainThreadMarshaller : IMainThreadMarshaller
    {
        public void RunOnMainThread(Action toRun)
        {
            MainActivityLocator.Locate().RunOnUiThread(toRun);
        }
    }
}