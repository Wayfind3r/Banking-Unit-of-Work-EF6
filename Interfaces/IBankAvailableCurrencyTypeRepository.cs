using System.Collections.Generic;
using UnitOfWorkBanking.Entities;
using UnitOfWorkBanking.Enums;

namespace BankingUoW.Interfaces
{
    public interface IBankAvailableCurrencyTypeRepository
    {
        IEnumerable<BankAvilableCurrencyType> GetCurrencyTypesAvailableForBank(int bankId);
        IEnumerable<BankAvilableCurrencyType> GetCurrencyTypesAvailableForBanks(IEnumerable<int> bankIds, int page = 1,int pageSize = 10);
        
    }
}