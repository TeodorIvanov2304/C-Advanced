using SoftUniLoggerClassLibrary.Models;

namespace SoftUniLoggerClassLibrary.Layouts.Interfaces
{
    public interface ILayout
    {
        string Format(Message message);
    }
}
