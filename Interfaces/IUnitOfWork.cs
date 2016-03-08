using System;

namespace BankingUoW.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
         IBankRepository Banks { get; }
        IBankAccountRepository BankAccounts { get; }
        IBankAvailableCurrencyTypeRepository BankAvailableCurrencyTypes { get; }
        IClientRepository Clients { get; }
        ITransferRepository Transfers { get; }
        int SaveChanges();
    }
}