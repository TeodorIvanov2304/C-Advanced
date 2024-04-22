﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftUniDI_Framework.Interfaces
{
    public interface IModule
    {

        void Configure();
        Type GetMapping(Type currentInterface, object attribute);
        object GetInstance(Type type);
        void SetInstance(Type implementation,object instance);
    }
}
