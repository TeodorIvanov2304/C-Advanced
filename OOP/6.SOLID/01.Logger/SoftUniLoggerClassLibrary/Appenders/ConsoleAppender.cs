using SoftUniLoggerClassLibrary.Appenders.Interfaces;
using SoftUniLoggerClassLibrary.Layouts.Interfaces;
using SoftUniLoggerClassLibrary.Models;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace SoftUniLoggerClassLibrary.Appenders
{
    public class ConsoleAppender : IAppender
    {
        private ILayout _layout;
        public LogEntryLevel logLevel { get; set; } = 0;
        public ConsoleAppender(ILayout layout)
        {
            _layout = layout;
        }

        

        public void Append(Message message)
        {   
            
            Console.WriteLine(_layout.Format(message));
        }
    }
}
