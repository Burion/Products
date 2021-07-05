using ProductsWPF;
using ProductsWPF.IoC;

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
