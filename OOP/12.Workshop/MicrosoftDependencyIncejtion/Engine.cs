using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MicrosoftDependencyInjection
{
    internal class Engine
    {
        private IRandomGenerator generator;
        private ILogger logger;
        public Engine(IRandomGenerator generator, ILogger logger)
        {
            this.generator = generator;
            this.logger = logger;
        }

        public void Print()
        {
            logger.Log("Printing random number");
            Console.WriteLine(this.generator.GetRandom());
        }
    }
}
