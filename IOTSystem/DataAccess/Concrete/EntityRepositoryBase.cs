using IOTSystem.DataAccess.Abstract;
using IOTSystem.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace IOTSystem.DataAccess.Concrete
{
    internal class EntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var id = this.GetNextId();
                entity.GetType().GetProperties()[0].SetValue(entity, id);
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();

                return entity;
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                return context.Set<TEntity>().FirstOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()
                    : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public TEntity Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();

                return entity;
            }
        }

        private int GetNextId()
        {
            using (var context = new TContext())
            {
                var result = context.Set<TEntity>().ToList()
                    .Select(t => t.GetType().GetProperties()[0].GetValue(t)).LastOrDefault() as int?;

                return result + 1 ?? 1;
            }
        }

    }
}
