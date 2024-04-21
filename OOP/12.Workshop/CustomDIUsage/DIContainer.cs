

using CustomDependencyInversion.Interfaces;
using CustomDependencyInversion.Models;
using CustomDIUsage;
using IServiceProvider = CustomDependencyInversion.IServiceProvider;

namespace MicrosoftDependencyInjection.Dependency_Injection
{
    public class DIContainer
    {
        public static IServiceProvider BuildServiceProvider()
        {   
            
            IServiceCollection collection = new ServiceCollection();

            //Всеки път когато се поиска RandomGenerator, се връща SmallRandomGenerator
            collection.AddTransient<IRandomGenerator, SmallRandomGenerator>();
            collection.AddTransient<Engine, Engine>();
            collection.AddTransient<DateTime, DateTime>((serviceProvider) =>
            {
                return DateTime.Now;
            });



            return (IServiceProvider)collection.BuildServiceProvider();

        }
    }
}
