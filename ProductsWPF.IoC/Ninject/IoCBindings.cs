using AccessServices.Infrastructure;
using AccessServices.Interfaces;
using DataAccess;
using DataAccess.Infrastructure.EfCore;
using DataAccess.Interfaces;
using Ninject.Modules;
using System;

namespace ProductsWPF.IoC
{
    public class IoCBindings : NinjectModule
    {
        public override void Load()
        {
            Bind<ICategoryService>().To<CategoryServiceUniversal>();
            Bind<IDbAccesserCategory>().To<DbAccesserCategoryEF>();
            Bind<ProductsContext>().To<ProductsContext>();
        }
    }
}
