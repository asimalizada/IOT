using IOTSystem.Entities.Concrete;
using System.Collections.Generic;

namespace IOTSystem.Business.Abstract
{
    internal interface IOutcomeReasonService
    {
        OutcomeReason Add(OutcomeReason incomeReason);

        OutcomeReason Update(OutcomeReason incomeReason);

        void Delete(int id);

        OutcomeReason Get(int id);

        List<OutcomeReason> GetAll();

        List<OutcomeReason> GetByName(string name);
    }
}
