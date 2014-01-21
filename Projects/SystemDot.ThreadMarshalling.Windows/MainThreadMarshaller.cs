using System;
using System.Windows.Threading;

namespace SystemDot.ThreadMarshalling
{
    public class MainThreadMarshaller : IMainThreadMarshaller
    {
        public void RunOnMainThread(Action toRun)
        {
            Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Normal, toRun);
        }
    }
}
