using log4net;
using System;
using System.Diagnostics;

namespace ChennaiSarees.Infrastructure.Logging
{
    public class Log4NetLogger : ILogRepository
    {
        private readonly ILog _log;
        private readonly string _loggerId = Guid.NewGuid().ToString();

        public Log4NetLogger()
        {
            var factory = Log4NetLoggerFactory.GetLog4NetLoggerFactory();
            _log = factory.GetLogger(_loggerId);
        }

        #region ILogger Members

        void ILogRepository.Log(string message, LogMessageLevel level)
        {
            // Optimized switch testing for most likely level in production scenario first followed by less common levels then debug levels.
            // Log4Net level hierarchy is: DEBUG < INFO < WARN < ERROR < FATAL.
            // Each log4net setting logs its own and lower levels in the hierarchy - e.g. DEBUG logs all levels, FATAL only logs Fatal level.
            switch (level)
            {
                case LogMessageLevel.Warning:
                    // Test first as its most likely production setting and should occur more often than higher levels.
                    _log.Warn(message);
                    break;

                case LogMessageLevel.Error:
                    _log.Error(message);
                    break;

                case LogMessageLevel.Fatal:
                    _log.Fatal(message);
                    break;

                case LogMessageLevel.Verbose:
                    _log.Info(message);
                    break;

                case LogMessageLevel.Debug:
                    _log.Debug(message);
                    break;

                default:
                    _log.Info(message);
                    break;
            }
        }

        void ILogRepository.Log(Exception ex)
        {
            Debug.Assert(_log != null, "Null ILog object.");

            if (ex != null)
            {
                var baseEx = ex.GetBaseException();
                _log.Error(string.Format("{0}.{1}.{2}.{3}.{4}", baseEx.Source, baseEx.TargetSite, baseEx.InnerException, baseEx.Source, baseEx.StackTrace), ex);
            }
        }

        string ILogRepository.LoggerId
        {
            get { return _loggerId; }
        }

        #endregion ILogger Members
    }
}