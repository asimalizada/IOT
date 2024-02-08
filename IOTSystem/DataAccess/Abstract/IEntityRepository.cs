using IOTSystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace IOTSystem.DataAccess.Abstract
{
    internal interface IEntityRepository<T> where T : class, IEntity, new()
    {
        T Add(T entity);

        T Update(T entity);

        void Delete(T entity);

        T Get(Expression<Func<T, bool>> filter);

        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
