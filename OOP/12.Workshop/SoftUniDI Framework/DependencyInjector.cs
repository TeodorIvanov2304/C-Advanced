using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniDI_Framework
{
    using SoftUniDI_Framework.Interfaces;
    using SoftUniDI_Framework.Injectors;
    using SoftUniDI_Framework.Modules;

    public class DInjector
    {
        public static Injector CreateInjector(IModule module)
        {
            module.Configure();
            return new Injector(module);
        }
    }
}
