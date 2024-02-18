using IOTSystem.Entities.Concrete;
using System.Collections.Generic;

namespace IOTSystem.Business.Abstract
{
    internal interface IBalanceService
    {
        Balance Add(Balance balance);

        Balance Update(Balance balance);

        void Delete(int id);

        Balance Get(int id);

        List<Balance> GetAll();
    }
}
