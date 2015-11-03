using System;

namespace ChennaiSarees.Infrastructure.Logging
{
    /// <summary>
    /// Interface for logging messages or exceptions.
    /// </summary>
    public interface ILogRepository
    {
        /// <summary>
        /// Operating for logging a message.
        /// </summary>
        /// <param name="message">Message.</param>
        /// <param name="level">The severity level at which the logging should occur.</param>
        void Log(string message, LogMessageLevel level);

        /// <summary>
        /// Operation for logging exception.
        /// </summary>
        /// <param name="ex">Exception.</param>
        void Log(Exception ex);

        /// <summary>
        /// String identifying the logger instance.
        /// </summary>
        string LoggerId { get; }
    }
}