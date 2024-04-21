using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomDependencyInversion
{
    public interface IServiceProvider
    {
        T GetService<T>();

    }
}
