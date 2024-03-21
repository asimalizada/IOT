using IOTSystem.DataAccess.Abstract;
using IOTSystem.Entities.Concrete;
using IOTSystem.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IOTSystem.DataAccess.Concrete
{
    internal class IncomeRepository : EntityRepositoryBase<Income, IOTContext>, IIncomeRepository
    {
        public List<IncomeDto> GetAllIncomes(Expression<Func<Income, bool>> predicate = null)
        {
            using(var context = new IOTContext())
            {
                var result = from i in predicate is null ? context.Incomes : context.Incomes.Where(predicate)
                             join b in context.Balances on i.BalanceId equals b.Id
                             join r in context.IncomeReasons on i.ReasonId equals r.Id
                             select new IncomeDto
                             {
                                 Id = i.Id,
                                 Name = i.Name,
                                 Description = i.Description,
                                 Date = i.Date,
                                 Amount = i.Amount,
                                 BalanceId = b.Id,
                                 BalanceName = b.Name,
                                 ReasonId = r.Id,
                                 ReasonName = r.Name
                             };

                return result.ToList();
            }
        }
    }
}
