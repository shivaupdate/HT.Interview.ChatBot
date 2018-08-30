using System;

namespace HT.Framework.Contracts
{
    public interface ILogger
    {
        /// <summary>
        ///     Writes a debug message to the default Hexaware log.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <seealso cref="InfrastructureConstants.LogNames.Hexaware" />
        void Debug(string message);

        /// <summary>
        ///     Writes a debug message to the default Hexaware log.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <param name="exception"></param>
        /// <seealso cref="InfrastructureConstants.LogNames.Hexaware" />
        void Debug(string message, Exception exception);

        /// <summary>
        ///     Writes a debug message to the specified log.
        /// </summary>
        /// <param name="logName">The log name.</param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void DebugToLog(string logName, string message, Exception exception);

        /// <summary>
        ///     Writes an error message to the default Hexaware log.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <seealso cref="InfrastructureConstants.LogNames.Hexaware" />
        void Error(string message);

        /// <summary>
        ///  Writes an error message to the default Hexaware log.
        /// </summary>
        /// <param name="message">
        ///  The log message. </param>
        /// <param name="exception">
        ///  The Exception to be logged. </param>
        void Error(string message, Exception exception);

        /// <summary>
        ///     Writes an error message to the specified log.
        /// </summary>
        /// <param name="logName">The log name.</param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void ErrorToLog(string logName, string message, Exception exception);

        /// <summary>
        ///     Writes a fatal error message to the default Hexaware log.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <seealso cref="InfrastructureConstants.LogNames.Hexaware" />
        void Fatal(string message);

        /// <summary>
        ///     Writes a fatal error message to the default Hexaware log.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <seealso cref="InfrastructureConstants.LogNames.Hexaware" />
        void Fatal(string message, Exception exception);

        /// <summary>
        ///     Writes a fatal error message to the specified log.
        /// </summary>
        /// <param name="logName">The log name.</param>
        /// <param>The format string.
        ///     <name>format</name>
        /// </param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void FatalToLog(string logName, string message, Exception exception);

        /// <summary>
        ///     Writes information to the default Hexaware log.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <seealso cref="InfrastructureConstants.LogNames.Hexaware" />
        void Info(string message);

        /// <summary>
        ///     Writes information to the default Hexaware log.
        /// </summary>
        ///  <param name="message">The log message.</param>
        /// <param name="exception">The exception to be logged</param>
        /// <seealso cref="InfrastructureConstants.LogNames.Hexaware" />
        void Info(string message, Exception exception);

        /// <summary>
        ///     Writes information to the specified log.
        /// </summary>
        /// <param name="logName">The log name.</param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void InfoToLog(string logName, string message, Exception exception);

        /// <summary>
        ///     Writes a warning to the default Hexaware log.
        /// </summary>
        /// <param name="message">The log message.</param>
        /// <seealso cref="InfrastructureConstants.LogNames.Hexaware" />
        void Warn(string message);

        /// <summary>
        ///     Writes a warning to the default Hexaware log.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        /// <seealso cref="InfrastructureConstants.LogNames.Hexaware" />
        void Warn(string message, Exception exception);

        /// <summary>
        ///     Writes a warning to the specified log.
        /// </summary>
        /// <param name="logName">The log name.</param>
        /// <param name="message"></param>
        /// <param name="exception"></param>
        void WarnToLog(string logName, string message, Exception exception);
    }
}