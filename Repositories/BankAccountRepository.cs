using System;
using System.Collections.Generic;
using System.Linq;
using BankingUoW.Interfaces;
using UnitOfWorkBanking.DbContext;
using UnitOfWorkBanking.Entities;
using UnitOfWorkBanking.Enums;

namespace BankingUoW.Repository
{
    public class BankAccountRepository : Repository<BankAccount>, IBankAccountRepository
    {
        public BankAccountRepository(ApplicationDbContext context):base(context)
        {}
        //Returns BankAccounts by Bank.bankId
        //Single bankId overload
        //supports paging
        public IEnumerable<BankAccount> GetBankAccountsByBank(int bankId, int page = 1, int pageSize = 10)
        {
            var result =
                Context.Set<BankAccount>().Where(x => x.BankId == bankId).
                Skip((page - 1)*pageSize).Take(pageSize).AsEnumerable();
            return result;
        }
        /// <summary>
        /// Returns Bank accounts by Bank.BankId
        /// Multiple bankIds overload
        /// supports paging
        /// </summary>
        /// <param name="bankIds">IEnumerable of bankIds to query for</param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<BankAccount> GetBankAccountsByBank(IEnumerable<int> bankIds, int page = 1, int pageSize = 10)
        {
            var result = Context.Set<BankAccount>().Where(x => bankIds.Any(y => y == x.BankId)).
                Skip((page - 1)*pageSize).Take(pageSize).AsEnumerable();
            return result;
        }
        /// <summary>
        /// Returns BankAccounts made in a specific DateTime range
        /// parameters are nullable
        /// Null parameters are handled as non-existent
        /// </summary>
        /// <param name="start">nullable</param>
        /// <param name="end">nullable</param>
        /// <returns></returns>
        public IEnumerable<BankAccount> GetBankAccountsMadeInRange(DateTime? start, DateTime? end)
        {
            IEnumerable<BankAccount> result = null;
            if (start != null)
            {
                if (end != null)
                {
                    result =
                        Context.Set<BankAccount>().
                        Where(x => x.DateOfCreation >= start || x.DateOfCreation <= end).
                            AsEnumerable();
                    return result;
                }
                result = Context.Set<BankAccount>().Where(x => x.DateOfCreation >= start).AsEnumerable();
                return result;
            }
            if (end != null)
            {
                result = Context.Set<BankAccount>().Where(x => x.DateOfCreation <= end).
                    AsEnumerable();
            }
            return result;
        }
        /// <summary>
        /// Return BankAccounts with base currency in specific range
        /// decimal parameters are nullable
        /// null parameters are handled as non-existent
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="lower">nullable</param>
        /// <param name="higher">nullable</param>
        /// <returns></returns>
        public IEnumerable<BankAccount> GetBankAccountsWithBalanceInRange(CurrencyType currency, decimal? lower,
            decimal? higher)
        {
            IEnumerable<BankAccount> result = null;
            if (lower != null)
            {
                if (higher != null)
                {
                    result =
                        Context.Set<BankAccount>()
                            .Where(x => x.CurrencyType == currency && x.Balance >= lower && x.Balance <= higher)
                            .AsEnumerable();
                    return result;
                }
                result = Context.Set<BankAccount>()
                    .Where(x => x.CurrencyType == currency && x.Balance >= lower)
                    .AsEnumerable();
                return result;
            }
            if (higher != null)
            {
                result =
                    Context.Set<BankAccount>()
                        .Where(x => x.CurrencyType == currency && x.Balance <= higher)
                        .AsEnumerable();
            }
            return result;
        }
    }
}