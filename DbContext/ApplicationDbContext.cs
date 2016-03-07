using System.Data.Entity;
using UnitOfWorkBanking.Entities;

namespace UnitOfWorkBanking.DbContext
{
    public class ApplicationDbContext : System.Data.Entity.DbContext
    {
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<BankAccount> BankAccounts { get; set; }
        public virtual DbSet<Bank> Banks { get; set; }
        public virtual DbSet<Transfer> Transfers { get; set; }
        public virtual DbSet<BankAvilableCurrencyType> BankAvilableCurrencyTypes { get; set; }
    }
}