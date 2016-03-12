using System.Collections.Generic;
using System.Linq;
using BankingUoW.Interfaces;
using UnitOfWorkBanking.DbContext;
using UnitOfWorkBanking.Entities;
using UnitOfWorkBanking.Enums;

namespace BankingUoW.Repository
{
    public class TransferRepository : Repository<Transfer>, ITransferRepository
    {
         //pass DbContext to base class
        public TransferRepository(ApplicationDbContext context):base(context)
        {
        }
        /// <summary>
        /// Get all transfers between 2 account Ids
        /// Checks for both Id1 to Id2 and Id2 to Id1
        /// </summary>
        /// <param name="firstAccountId"></param>
        /// <param name="secondAccountId"></param>
        /// <returns></returns>
        public IEnumerable<Transfer> GetTransfersBetweenAccounts(int firstAccountId, int secondAccountId)
        {
            IEnumerable<Transfer> result = null;
            result = Context.Set<Transfer>()
                .Where(x => (x.BankAccountId == firstAccountId && x.TargetBankAccountId == secondAccountId)
                            || (x.BankAccountId == secondAccountId || x.TargetBankAccountId == firstAccountId))
                .AsEnumerable();
            return result;
        }
        /// <summary>
        /// Get all transfers with a given CurrencyType in a certain amount range
        /// Checks if lower or higher is null and ignores null values
        /// </summary>
        /// <param name="currency">CurrencyType</param>
        /// <param name="lower">Nullable</param>
        /// <param name="higher">Nullable</param>
        /// <returns></returns>
        public IEnumerable<Transfer> GetTransfersWithCurrencyTypeInRange(CurrencyType currency, decimal? lower,
            decimal? higher)
        {
            IEnumerable<Transfer> result = null;
            if (lower != null)
            {
                if (higher != null)
                {
                    result = Context.Set<Transfer>()
                        .Where(x => x.CurrencyType == currency && x.Amount >= lower && x.Amount <= higher)
                        .AsEnumerable();
                    return result;
                }
                result = Context.Set<Transfer>()
                    .Where(x => x.CurrencyType == currency && x.Amount >= lower)
                    .AsEnumerable();
                return result;
            }
            if (higher != null)
            {
                result = Context.Set<Transfer>()
                    .Where(x => x.CurrencyType == currency && x.Amount <= higher)
                    .AsEnumerable();
                return result;
            }
            result = Context.Set<Transfer>()
                .Where(x => x.CurrencyType == currency)
                .AsEnumerable();
            return  result;
        } 
    }
}