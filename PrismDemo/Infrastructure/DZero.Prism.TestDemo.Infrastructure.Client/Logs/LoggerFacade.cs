using log4net;
using log4net.Config;
using Prism.Logging;
using System;
using System.Reflection;

[assembly: XmlConfigurator(Watch = true)]
namespace DZero.Prism.TestDemo.Infrastructure.Client.Logs
{
    public class LoggerFacade : ILoggerFacade, IDisposable
    {
        private readonly ILog logger;
        public LoggerFacade()
        {
            logger = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);
        }

        public void Log(string message, Category category, Priority priority)
        {
            var loggerMessage = new LoggerMessage()
            {
                Message = message,
                Category = category.ToString().ToUpper(),
                Priority = priority.ToString()
            };

            switch (category)
            {
                case Category.Debug:
                    Debug(loggerMessage);
                    break;
                case Category.Exception:
                    Error(loggerMessage);
                    break;
                case Category.Info:
                    Info(loggerMessage);
                    break;
                case Category.Warn:
                    Warn(loggerMessage);
                    break;
                default:
                    break;
            }
        }

        private void Debug(object message)
        {
            if (logger.IsDebugEnabled)
                logger.Debug(message);
        }

        private void Info(object message)
        {
            if (logger.IsInfoEnabled)
                logger.Info(message);
        }

        private void Warn(object message)
        {
            if (logger.IsWarnEnabled)
                logger.Warn(message);
        }

        private void Error(object message)
        {
            if (logger.IsFatalEnabled)
                logger.Fatal(message);
            if (logger.IsErrorEnabled && !logger.IsFatalEnabled)
                logger.Error(message);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
