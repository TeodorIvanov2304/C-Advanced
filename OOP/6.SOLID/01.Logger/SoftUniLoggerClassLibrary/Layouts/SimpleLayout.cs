using SoftUniLoggerClassLibrary.Layouts.Interfaces;
using SoftUniLoggerClassLibrary.Models;

namespace SoftUniLoggerClassLibrary.Layouts
{
    public class SimpleLayout : ILayout
    {
        public string Format(Message message)
        {
            return $"{message.DateTime} - {message.LogEntryLevel} - {message.LogMessage}";
        }
    }
}
