using IOTSystem.Business.Abstract;
using IOTSystem.Business.Concrete;
using Ninject.Modules;

namespace IOTSystem.Business
{
    internal class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserService>().To<UserService>().InSingletonScope();
            Bind<IIncomeService>().To<IncomeService>().InSingletonScope();
            Bind<IOutcomeService>().To<OutcomeService>().InSingletonScope();
            Bind<IIncomeReasonService>().To<IncomeReasonService>().InSingletonScope();
            Bind<IOutcomeReasonService>().To<OutcomeReasonService>().InSingletonScope();
            Bind<IBalanceService>().To<BalanceService>().InSingletonScope();
        }
    }
}
