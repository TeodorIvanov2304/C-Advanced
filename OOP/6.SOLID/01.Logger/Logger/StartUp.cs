using SoftUniLoggerClassLibrary.Appenders;
using SoftUniLoggerClassLibrary.Appenders.Interfaces;
using SoftUniLoggerClassLibrary.Factories;
using SoftUniLoggerClassLibrary.Layouts;
using SoftUniLoggerClassLibrary.Layouts.Interfaces;
using SoftUniLoggerClassLibrary.Loggers;
using SoftUniLoggerClassLibrary.Loggers.Interfaces;
using SoftUniLoggerClassLibrary.Models;
using System.Globalization;

namespace _01._Logger
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            //ILogger logger = InitializeWithoutPatterns();
            //ILogger consoleLogger = InitializeWithFactory();
            //logger.Info(DateTime.Now, "It works!");
            //consoleLogger.Info(DateTime.Now, "It works!");

            List<IAppender> appenders = new List<IAppender>();
            int numberOfAppenders = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] appenderData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
                
                ILayout layout = new SimpleLayout();
                switch (appenderData[1])
                {
                    case "SimpleLayout":
                        layout = new SimpleLayout();
                        break;
                    case "xmlLayout":
                        layout = new XmlLayout();
                        break;
                    default:
                        Console.WriteLine("Invalid layout");
                        break;
                }

                IAppender appender = new ConsoleAppender(layout);

                switch (appenderData[0])
                {
                    case "ConsoleAppender":
                        appender = new ConsoleAppender(layout);
                        break;
                    case "FileAppender":
                        appender = new FileAppender(layout);
                        break;
                }

                if (appenderData.Length == 3)
                {
                    switch (appenderData[2])
                    {

                        case "INFO":
                            appender.logLevel = LogEntryLevel.Info;
                            break;
                        case "WARNING":
                            appender.logLevel = LogEntryLevel.Warning;
                            break;
                        case "ERROR":
                            appender.logLevel = LogEntryLevel.Error;
                            break;
                        case "CRITICAL":
                            appender.logLevel = LogEntryLevel.Critical;
                            break;
                        case "FATAL":
                            appender.logLevel = LogEntryLevel.Fatal;
                            break;
                        
                    }
                }

                appenders.Add(appender);
            }

            ILogger logger = new Logger(appenders);

            string input = "";
            while ((input = Console.ReadLine()) != "END")
            {
                string[] data = input.Split('|', StringSplitOptions.RemoveEmptyEntries);
                
                switch (data[0])
                {
                    case "INFO":
                        logger.Info(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "WARNING":
                        logger.Warning(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "ERROR":
                        logger.Error(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "CRITICAl":
                        logger.Critical(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                    case "FATAL":
                        logger.Fatal(DateTime.Parse(data[1], CultureInfo.InvariantCulture), data[2]);
                        break;
                }
            }
        }

        private static ILogger InitializeWithoutPatterns()
        {
            ILayout simpleLayout = new SimpleLayout();
            ILayout xmlLayout = new XmlLayout();

            IAppender consoleAppender = new ConsoleAppender(simpleLayout);
            IAppender fileAppender = new FileAppender(simpleLayout);
            consoleAppender.logLevel = SoftUniLoggerClassLibrary.Models.LogEntryLevel.Critical;

            ILogger logger = new Logger(fileAppender);
            logger.AddAppender(consoleAppender);
            return logger;
        }

        private static ILogger InitializeWithFactory()
        {
            var loggerFactory = new LoggerFactory();
            ILogger consoleLogger = loggerFactory.CreateLogger("console");
            ILogger fileLogger = loggerFactory.CreateLogger("file");
            return consoleLogger;
        }
    }
}