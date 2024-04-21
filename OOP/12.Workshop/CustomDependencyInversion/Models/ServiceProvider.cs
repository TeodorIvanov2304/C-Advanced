using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CustomDependencyInversion.Models
{
    internal class ServiceProvider : IServiceProvider
    {
        private ServiceCollection serviceCollection;

        public ServiceProvider(ServiceCollection serviceCollection)
        {
            this.serviceCollection = serviceCollection;
        }

        public T GetService<T>()
        {
            return (T)GetService(typeof(T));
        }

        private object GetService(Type interfaceType)
        {
            if (serviceCollection.TransientMappingsWithFactories.ContainsKey(interfaceType))
            {
                return serviceCollection.TransientMappingsWithFactories[interfaceType](this);
            }

            Type implementationType = serviceCollection.TransientMappings[interfaceType];
            //Взимаме информатцията за конструктора с Reflection. Взимаме само първия конструктор[0]
            ConstructorInfo constructor = implementationType.GetConstructors()[0];
            //Взимаме информацията за параметрите на конструктора
            ParameterInfo[] parameters = constructor.GetParameters();
            //Създаваме масив от обекти, който има дължина колкото са параметрите
            object[] parameterObjects = new object[parameters.Length];
            int index = 0;
            foreach (ParameterInfo parameter in parameters)
            {
                parameterObjects[index++] = GetService(parameter.ParameterType);
            }

            //Връщаме създадената чрез Reflection инстанция
            return Activator.CreateInstance(implementationType, parameterObjects);
        }
    }
}
