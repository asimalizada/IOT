using IOTSystem.Entities.Dto;
using System.Collections.Generic;

namespace IOTSystem.Business.Abstract
{
    internal interface IIncomeService
    {
        IncomeDto Add(IncomeDto income);

        IncomeDto Update(IncomeDto income);

        void Delete(int id);

        IncomeDto Get(int id);

        List<IncomeDto> GetAll();
    }
}
