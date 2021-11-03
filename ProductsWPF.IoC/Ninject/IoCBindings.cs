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
            Bind<ICategoryService>().To<CategoryService>();
            Bind<IDbAccesserCategory>().To<DbAccesserCategoryEF>().InTransientScope();
            Bind<ProductsContext>().To<ProductsContext>();

            Bind<IProductService>().To<ProductService>();
            Bind<IDbAccesserProduct>().To<DbAccesserProductEF>();
        }
    }
}
