using System;
using System.Reflection;

namespace SystemDot.Logging
{
    public class Log4NetLoggingMechanism : ILoggingMechanism
    {
        //readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        public bool ShowInfo { get; set; }

        public bool ShowDebug { get; set; }

        public Log4NetLoggingMechanism()
        {
            //XmlConfigurator.Configure();
        }

        public void Info(string message)
        {
            //this.log.Info(message);
        }

        public void Debug(string message)
        {
            //this.log.Debug(message);
        }

        public void Error(Exception exception)
        {
            //this.log.Error(exception.Message);
        }
    }
}