using AccessServices.Infrastructure;
using AccessServices.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProductsWPF.IoC
{
    class ClassLocator
    {
        public ICategoryService ICategoryService
        {
            get
            {
                var kernel = new StandardKernel();
                kernel.Load(Assembly.GetExecutingAssembly());
                return kernel.Get<ICategoryService>();
            }
        }
    }
}
