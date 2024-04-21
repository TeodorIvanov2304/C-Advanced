using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDependencyInversion.Interfaces
{
    public interface IServiceCollection
    {   
        //AddTransient
        public void AddTransient<TInterface, TImplementation>();
        //TImplementation или object??
        public void AddTransient<TInterface, TImplementation>(Func<IServiceProvider,object> factory);

        //AddSingleton
        public void AddSingleton<TInterface, TImplementation>();
        public void AddSingleton<TInterface, TImplementation>(Func<IServiceProvider, TImplementation> factory);

        IServiceProvider BuildServiceProvider();
    }
}
