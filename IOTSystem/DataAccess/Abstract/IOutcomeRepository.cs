using IOTSystem.Entities.Concrete;
using IOTSystem.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IOTSystem.DataAccess.Abstract
{
    internal interface IOutcomeRepository : IEntityRepository<Outcome>
    {
        List<OutcomeDto> GetAllOutcomes(Expression<Func<Outcome, bool>> predicate = null);
    }
}
