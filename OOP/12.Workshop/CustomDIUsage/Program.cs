using MicrosoftDependencyInjection.Dependency_Injection;
using IServiceProvider = CustomDependencyInversion.IServiceProvider;
namespace CustomDIUsage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IServiceProvider serviceProvider = DIContainer.BuildServiceProvider();
            Engine engine = serviceProvider.GetService<Engine>();

            engine.Something();
        }
    }

    interface IRandomGenerator
    {
        public int GetRandom();
    }

    public class SmallRandomGenerator : IRandomGenerator
    {

        public SmallRandomGenerator(DateTime dateToday)
        {
            Console.WriteLine("Small random generator created");
        }
        public int GetRandom()
        {
            return new Random().Next(0, 10);
        }
    }
}