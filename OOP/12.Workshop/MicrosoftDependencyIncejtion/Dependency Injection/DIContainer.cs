using Microsoft.Extensions.DependencyInjection;
using MicrosoftDependencyInjection.Loggers;

namespace MicrosoftDependencyInjection.Dependency_Injection
{
    public class DIContainer
    {
        public static IServiceProvider BuildServiceProvider()
        {   
            //Binding between interfaces and objects
            //Създаваме колекция от услуги
            ServiceCollection collection = new ServiceCollection();

            //Всеки път когато се поиска RandomGenerator, се връща SmallRandomGenerator
            collection.AddTransient<IRandomGenerator, SmallRandomGenerator>();
            //Всеки път, когато трябва Engine, ми връщай Engine. Te IServiceProvider ще създава Engine вместо нас, със всичките му параметри
            collection.AddTransient<Engine, Engine>();
            //Винаги връщаме ConsoleLogger, когато ни трябва логер
            //collection.AddTransient<ILogger, ConsoleLogger>();
            collection.AddTransient<ILogger, PurpleConsoleLogger>();

            return collection.BuildServiceProvider();

        }
    }
}
