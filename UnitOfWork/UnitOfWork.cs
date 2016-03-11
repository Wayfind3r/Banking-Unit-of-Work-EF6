using System.Data.Entity;
using BankingUoW.Interfaces;
using BankingUoW.Repository;
using UnitOfWorkBanking.DbContext;

namespace BankingUoW.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext Context;
        public IBankRepository Banks { get; private set; }
        public IBankAccountRepository BankAccounts { get; private set; }
        public IBankAvailableCurrencyTypeRepository BankAvailableCurrencyTypes { get; private set; }
        public IClientRepository Clients { get; private set; }
        public ITransferRepository Transfers { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            this.Context = context;
            Banks = new BankRepository(context);
            BankAccounts = new BankAccountRepository(context);
            BankAvailableCurrencyTypes = new BankAvailableCurrencyTypeRepository(context);
            ////set repositories here
        }

        public int SaveChanges()
        {
            return Context.SaveChanges();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}