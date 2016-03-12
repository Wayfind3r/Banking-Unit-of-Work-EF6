using System.Collections.Generic;
using UnitOfWorkBanking.Entities;
using UnitOfWorkBanking.Enums;

namespace BankingUoW.Interfaces
{
    public interface ITransferRepository
    {
        IEnumerable<Transfer> GetTransfersBetweenAccounts(int firstAccountId, int secondAccountId);
        IEnumerable<Transfer> GetTransfersWithCurrencyTypeInRange(CurrencyType currency, decimal? lower, decimal? higher);

    }
}