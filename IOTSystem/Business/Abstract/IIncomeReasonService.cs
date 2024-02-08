using IOTSystem.Entities.Concrete;
using System.Collections.Generic;

namespace IOTSystem.Business.Abstract
{
    internal interface IIncomeReasonService
    {
        IncomeReason Add(IncomeReason incomeReason);

        IncomeReason Update(IncomeReason incomeReason);

        void Delete(int id);

        IncomeReason Get(int id);

        List<IncomeReason> GetAll();

        List<IncomeReason> GetByname(string name);
    }
}
