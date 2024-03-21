using IOTSystem.Entities.Concrete;
using IOTSystem.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IOTSystem.DataAccess.Abstract
{
    internal interface IIncomeRepository : IEntityRepository<Income>
    {
        List<IncomeDto> GetAllIncomes(Expression<Func<Income, bool>> predicate = null);
    }
}
