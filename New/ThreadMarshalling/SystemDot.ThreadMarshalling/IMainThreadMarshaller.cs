using System;

namespace SystemDot.ThreadMarshalling
{
    public interface IMainThreadMarshaller
    {
        void RunOnMainThread(Action toRun);
    }
}