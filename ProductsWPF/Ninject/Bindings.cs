﻿using AccessServices.Infrastructure;
using AccessServices.Interfaces;

using Ninject.Modules;
using ProductsWPF;
using ProductsWPF.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessServices.Ninject
{
    public class Bindings : IoCBindings
    {
        public override void Load()
        {
            Bind<Categories>().ToSelf().InTransientScope();
            base.Load();
        }
    }
}
