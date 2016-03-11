using System.Collections.Generic;
using UnitOfWorkBanking.Entities;
using UnitOfWorkBanking.Enums;

namespace BankingUoW.Interfaces
{
    public interface IBankRepository : IRepository<Bank>
    {
        IEnumerable<Bank> GetBanksByAvailableCurrency(CurrencyType currency);
        IEnumerable<Bank> GetBanksByAvailableCurrencies(HashSet<CurrencyType> currency);
        IEnumerable<Bank> GetBanksByAddress(string address, int pageNumber = 1, int pageSize = 10);
        IEnumerable<Bank> GetBanksByName(string name, int pageNumber = 1, int pageSize = 10);
    }
}