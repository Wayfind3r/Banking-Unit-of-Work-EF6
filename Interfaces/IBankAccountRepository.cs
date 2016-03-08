using System;
using System.Collections.Generic;
using UnitOfWorkBanking.Entities;
using UnitOfWorkBanking.Enums;

namespace BankingUoW.Interfaces
{
    public interface IBankAccountRepository :IRepository<BankAccount>
    {
        IEnumerable<BankAccount> GetBankAccountsByBank(int bankId, int page = 1, int pageSize = 10);
        IEnumerable<BankAccount> GetBankAccountsByBank(IEnumerable<int> bankIds, int page = 1, int pageSize = 10);
        IEnumerable<BankAccount> GetBankAccountsMadeInRange(DateTime start, DateTime end);
        IEnumerable<BankAccount> GetBankAccountsWithBalanceInRange(CurrencyType currency, decimal? lower, decimal? higher);
    }
}