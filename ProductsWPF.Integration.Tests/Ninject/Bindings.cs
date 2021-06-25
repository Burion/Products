using AccessServices.Infrastructure;
using AccessServices.Interfaces;
using DataAccess;
using DataAccess.Infrastructure.EfCore;
using DataAccess.Interfaces;
using Ninject.Modules;
using ProductsWPF.IoC;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductsWPF.Integration.Tests.Ninject
{
    public class Bindings : IoCBindings
    {
        public override void Load()
        {
            base.Load();
            Rebind<ProductsContext>().To<ProductsContextInMemory>();
        }
    }
}
