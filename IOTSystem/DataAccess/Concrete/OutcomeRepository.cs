using IOTSystem.DataAccess.Abstract;
using IOTSystem.Entities.Concrete;

namespace IOTSystem.DataAccess.Concrete
{
    internal class OutcomeRepository : EntityRepositoryBase<Outcome, IOTContext>, IOutcomeRepository
    {
    }
}
