using IOTSystem.Entities.Concrete;
using System.Collections.Generic;

namespace IOTSystem.Business.Abstract
{
    internal interface IIncomeService
    {
        Income Add(Income income);

        Income Update(Income income);

        void Delete(int id);

        Income Get(int id);

        List<Income> GetAll();
    }
}
