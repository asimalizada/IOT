using IOTSystem.DataAccess.Abstract;
using IOTSystem.DataAccess.Concrete;
using Ninject.Modules;

namespace IOTSystem.DataAccess
{
    internal class DataAccessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>().InSingletonScope();
            Bind<IIncomeRepository>().To<IncomeRepository>().InSingletonScope();
            Bind<IOutcomeRepository>().To<OutcomeRepository>().InSingletonScope();
            Bind<IIncomeReasonRepository>().To<IncomeReasonRepository>().InSingletonScope();
            Bind<IOutcomeReasonRepository>().To<OutcomeReasonRepository>().InSingletonScope();
        }
    }
}
