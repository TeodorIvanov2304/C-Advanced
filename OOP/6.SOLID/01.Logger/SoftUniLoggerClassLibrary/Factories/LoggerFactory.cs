using SoftUniLoggerClassLibrary.Appenders;
using SoftUniLoggerClassLibrary.Appenders.Interfaces;
using SoftUniLoggerClassLibrary.Layouts;
using SoftUniLoggerClassLibrary.Layouts.Interfaces;
using SoftUniLoggerClassLibrary.Loggers;
using SoftUniLoggerClassLibrary.Loggers.Interfaces;

namespace SoftUniLoggerClassLibrary.Factories
{
    public class LoggerFactory
    {
        public ILogger CreateLogger(string type)
        {
            ILayout layout;
            IAppender appender;

            layout = new SimpleLayout();

            switch (type)
            {
                case "console":
                    appender = new ConsoleAppender(layout);
                    break;
                case "file":
                    appender = new FileAppender(layout);
                    break;
                default: throw new ArgumentException("Invalid appender type");
                    
            }

            return new Logger(appender);
        }
    }
}
