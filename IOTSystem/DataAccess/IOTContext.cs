using IOTSystem.Entities.Concrete;
using System.Data.Entity;

namespace IOTSystem.DataAccess
{
    internal class IOTContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Income> Incomes { get; set; }

        public DbSet<Outcome> Outcomes { get; set; }

        public DbSet<IncomeReason> IncomeReasons { get; set; }

        public DbSet<OutcomeReason> OutcomeReasons { get; set; }

        public DbSet<Balance> Balances { get; set; }
    }
}
