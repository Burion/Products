using DataAccess;
using ProductsWPF.IoC;

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
