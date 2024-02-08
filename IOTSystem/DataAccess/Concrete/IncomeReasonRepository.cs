using IOTSystem.DataAccess.Abstract;
using IOTSystem.Entities.Concrete;

namespace IOTSystem.DataAccess.Concrete
{
    internal class IncomeReasonRepository : EntityRepositoryBase<IncomeReason, IOTContext>, IIncomeReasonRepository
    {
    }
}
