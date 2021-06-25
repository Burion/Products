using DataAccess.Infrastructure.EfCore;
using DataAccess.Interfaces;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess;
namespace AccessServices.Ninject
{
    class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<IDbAccesserCategory>().To<DbAccesserCategoryEF>();
            Bind<ProductsContext>().To<ProductsContext>();

        }
    }
}
