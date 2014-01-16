using System;

namespace SystemDot.Core
{
    public interface ISystemTime
    {
        DateTime GetCurrentDate();

        TimeSpan SpanFromSeconds(int seconds);
    }
}