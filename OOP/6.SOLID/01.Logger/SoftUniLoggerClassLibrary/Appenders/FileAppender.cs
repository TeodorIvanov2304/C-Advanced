using SoftUniLoggerClassLibrary.Appenders.Interfaces;
using SoftUniLoggerClassLibrary.Layouts.Interfaces;
using SoftUniLoggerClassLibrary.Models;


//Writing to a file
namespace SoftUniLoggerClassLibrary.Appenders
{
    public class FileAppender : IAppender
    {
        private ILayout layout;
        public LogEntryLevel logLevel { get; set; }
        public FileAppender(ILayout layout)
        {
            this.layout = layout;
        }

        public FileAppender(ILayout layout, string filePath) : this(layout)
        {
            FilePath = filePath;
        }

        public string FilePath { get; set; } = @$"..\\..\\..\\{DateTime.Now:yyyyMMddhhmmss}.txt";
        

        public void Append(Message message)
        {
            string formattedLogEntry = layout.Format(message);

            try
            {
                File.AppendAllText(FilePath, formattedLogEntry + Environment.NewLine);
            }
            catch (Exception e)
            {

                Console.WriteLine(e);
            }
        }
    }
}

	

