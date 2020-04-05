using Ninject.Modules;
using Socrat.Core.BL.PriceLists.Abstract;
using Socrat.Core.BL.PriceLists.Concrete;
using Socrat.Core.Repositories.Abstract;
using Socrat.DataProvider;


namespace Socrat.Startup.DI
{
    public class DependencyModule : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(ISocratRepository<>)).To(typeof(SqlSocratRepository<>)).InTransientScope().WithConstructorArgument("context", new SocratEntities());
            Bind<IPriceService>().To<PriceService>();
            Bind<IPriceInfo>().To<PriceInfo>();
        }
    }
}
