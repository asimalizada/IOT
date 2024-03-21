using IOTSystem.Entities.Dto;
using System.Collections.Generic;

namespace IOTSystem.Business.Abstract
{
    internal interface IBalanceService
    {
        BalanceDto Add(BalanceDto balance);

        BalanceDto Update(BalanceDto balance);

        void Delete(int id);

        BalanceDto Get(int id);

        List<BalanceDto> GetAll();
    }
}
