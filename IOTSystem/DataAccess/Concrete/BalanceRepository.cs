using IOTSystem.DataAccess.Abstract;
using IOTSystem.Entities.Concrete;

namespace IOTSystem.DataAccess.Concrete
{
    internal class BalanceRepository: EntityRepositoryBase<Balance, IOTContext>, IBalanceRepository
    {
    }
}
