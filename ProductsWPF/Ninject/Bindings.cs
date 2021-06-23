using AccessServices.Infrastructure;
using AccessServices.Interfaces;

using Ninject.Modules;
using ProductsWPF;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessServices.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryServiceUniversal>();
            Bind<Categories>().ToSelf().InTransientScope();
        }
    }
}
