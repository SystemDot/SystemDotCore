using System;
using Windows.UI.Core;

namespace SystemDot.ThreadMarshalling
{
    public class MainThreadMarshaller : IMainThreadMarshaller
    {
        readonly CoreDispatcher dispatcher;

        public MainThreadMarshaller()
        {
            dispatcher = CoreWindow.GetForCurrentThread().Dispatcher;
        }

        public async void RunOnMainThread(Action toRun)
        {
            await dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => toRun());
        }
    }
}
