using SoftUniLoggerClassLibrary.Models;

namespace SoftUniLoggerClassLibrary.Appenders.Interfaces
{
    public interface IAppender
    {   
        void Append(Message message);
        LogEntryLevel logLevel { get; set; }
        
    }
}
