using Microsoft.EntityFrameworkCore;

namespace Transactions.Server.Repository
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BalanceEntity>().HasKey(u => new
            {
                u.AccountNumber,
                u.Date
            });
        }

        public DbSet<AccountEntity> Accounts { get; set; }
        public DbSet<BalanceEntity> Balances { get; set; }
        public DbSet<TransactionEntity> Transactions { get; set; }
    }
}
