using IOTSystem.Entities;
using System.Data.Entity;

namespace IOTSystem.Extensions
{
    public static class DbSetExtensions
    {
        public static void Clear<T>(this DbSet<T> dbSet)
            where T : class, IEntity, new()
        {
            dbSet.RemoveRange(dbSet);
        }
    }
}
