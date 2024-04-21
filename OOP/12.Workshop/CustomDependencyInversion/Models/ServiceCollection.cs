using CustomDependencyInversion.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDependencyInversion.Models
{
    public class ServiceCollection : IServiceCollection
    {

        public ServiceCollection()
        {
            TransientMappings = new Dictionary<Type, Type>();
            TransientMappingsWithFactories = new Dictionary<Type, Func<IServiceProvider,object>>();
        }
        internal Dictionary<Type, Type> TransientMappings { get; set; }
        internal Dictionary<Type, Func<IServiceProvider, object>> TransientMappingsWithFactories { get; set; }
        public void AddTransient<TInterface, TImplementation>()
        {
            TransientMappings.Add(typeof(TInterface), typeof(TImplementation));
        }

        public void AddTransient<TInterface, TImplementation>(Func<IServiceProvider, object> factory)
        {
            TransientMappingsWithFactories.Add(typeof(TInterface), factory);
        }

        public void AddSingleton<TInterface, TImplementation>()
        {
            throw new NotImplementedException();
        }

        public void AddSingleton<TInterface, TImplementation>(Func<IServiceProvider, TImplementation> factory)
        {
            throw new NotImplementedException();
        }

        public IServiceProvider BuildServiceProvider()
        {
            return new ServiceProvider(this);
        }
    }
}
