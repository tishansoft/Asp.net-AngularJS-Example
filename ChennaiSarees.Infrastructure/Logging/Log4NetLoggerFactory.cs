using log4net;
using log4net.Config;

namespace ChennaiSarees.Infrastructure.Logging
{
    public class Log4NetLoggerFactory
    {
        private static readonly Log4NetLoggerFactory _factory = new Log4NetLoggerFactory();

        private Log4NetLoggerFactory()
        {
            XmlConfigurator.Configure();
        }

        internal static Log4NetLoggerFactory GetLog4NetLoggerFactory()
        {
            return _factory;
        }

        internal ILog GetLogger(string loggerId)
        {
            return LogManager.GetLogger(loggerId);
        }
    }
}