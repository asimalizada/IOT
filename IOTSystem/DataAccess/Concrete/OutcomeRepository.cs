using IOTSystem.DataAccess.Abstract;
using IOTSystem.Entities.Concrete;
using IOTSystem.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace IOTSystem.DataAccess.Concrete
{
    internal class OutcomeRepository : EntityRepositoryBase<Outcome, IOTContext>, IOutcomeRepository
    {
        public List<OutcomeDto> GetAllOutcomes(Expression<Func<Outcome, bool>> predicate = null)
        {
            using (var context = new IOTContext())
            {
                var result = from o in predicate is null ? context.Outcomes : context.Outcomes.Where(predicate)
                             join r in context.OutcomeReasons on o.ReasonId equals r.Id
                             join b in context.Balances on o.BalanceId equals b.Id
                             join oa in context.Outcomes on o.Alternative equals oa.Id into outcomeAlternative
                             from oa in outcomeAlternative.DefaultIfEmpty()
                             select new OutcomeDto
                             {
                                 Id = o.Id,
                                 Name = o.Name,
                                 Description = o.Description,
                                 Amount = o.Amount,
                                 Date = o.Date,
                                 IsAlternative = o.IsAlternative,
                                 Alternative =  oa == null ? 0 : oa.Alternative,
                                 AlternativeName = oa == null ? null : oa.Name,
                                 BalanceId = b.Id,
                                 BalanceName = b.Name,
                                 ReasonId = r.Id,
                                 ReasonName = r.Name
                             };

                var query = result.ToString();

                return result.ToList();
            }
        }
    }
}
