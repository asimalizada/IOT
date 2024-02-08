using IOTSystem.DataAccess.Abstract;
using IOTSystem.Entities.Concrete;

namespace IOTSystem.DataAccess.Concrete
{
    internal class IncomeRepository : EntityRepositoryBase<Income, IOTContext>, IIncomeRepository
    {
    }
}
