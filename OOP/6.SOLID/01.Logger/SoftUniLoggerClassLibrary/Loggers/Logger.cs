using SoftUniLoggerClassLibrary.Appenders.Interfaces;
using SoftUniLoggerClassLibrary.Loggers.Interfaces;
using SoftUniLoggerClassLibrary.Models;

namespace SoftUniLoggerClassLibrary.Loggers
{
    public class Logger : ILogger
    {
        private ICollection<IAppender> _appenders = new List<IAppender>();

        public Logger(IAppender appender)
        {
            //Adding a new appender to the list directly in the constructor
            _appenders.Add(appender);
        }

        public Logger(List<IAppender> appenders)
        {

            _appenders = appenders;
        }

        public void AddAppender(IAppender appender)
        {
            _appenders.Add(appender);
        }
        public void Critical(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Critical, logMessage));
        }

        public void Error(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Error, logMessage));
        }

        public void Fatal(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Fatal, logMessage));
        }

        public void Info(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Info, logMessage));
        }

        public void Warning(DateTime dateTime, string logMessage)
        {
            Log(new Message(dateTime, LogEntryLevel.Warning, logMessage));
        }

        private void Log(Message message)
        {
            foreach (var appender in _appenders)
            {
                if (message.LogEntryLevel >= appender.logLevel)
                {
                    appender.Append(message);
                }
                
            }
            
        }
    }
}
