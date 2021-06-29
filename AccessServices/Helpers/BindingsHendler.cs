using AccessServices.Ninject;
using DataAccess;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccessServices.Helpers
{
    public static class BindingsHendler
    {
        private readonly static StandardKernel _kernel;

        static BindingsHendler()
        {
            var module = new Bindings();
            var kernel = new StandardKernel(module);
            _kernel = kernel;
        }

        public static ProductsContext GetContext()
        {
            return _kernel.Get<ProductsContext>();
        }

        public static ProductsContext GetDbAccesserCategoryEF()
        {
            return _kernel.Get<ProductsContext>();
        }
    }
}