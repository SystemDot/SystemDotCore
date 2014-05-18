using System;
using System.Threading;
using SystemDot.Core;

namespace SystemDot.Messaging.Simple
{
    public class ReplyContext<TResponse> : Disposable
    {
        readonly static ThreadLocal<Action<TResponse>> CurrentResponseHandler = new ThreadLocal<Action<TResponse>>();

        public ReplyContext(Action<TResponse> responseHandler)
        {
            CurrentResponseHandler.Value = responseHandler;
        }

        public static void CallCurrentResponseHandler(TResponse response)
        {
            CurrentResponseHandler.Value.Invoke(response);
        }
    }
}