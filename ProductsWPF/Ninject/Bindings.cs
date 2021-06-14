using AccessServices.Infrastructure;
using AccessServices.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessServices.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryServiceDapper>();
        }
    }
}
