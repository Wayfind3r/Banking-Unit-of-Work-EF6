using System.Collections.Generic;
using System.Linq;
using BankingUoW.Interfaces;
using UnitOfWorkBanking.DbContext;
using UnitOfWorkBanking.Entities;

namespace BankingUoW.Repository
{
    public class BankAvailableCurrencyTypeRepository : Repository<BankAvilableCurrencyType>, IBankAvailableCurrencyTypeRepository
    {
        public BankAvailableCurrencyTypeRepository(ApplicationDbContext context):base(context)
        { }
        //Get Currency Types Available for Bank.bankId
        public IEnumerable<BankAvilableCurrencyType> GetCurrencyTypesAvailableForBank(int bankId)
        {
            var result = Context.Set<BankAvilableCurrencyType>()
                .Where(x => x.BankId == bankId)
                .AsEnumerable();
            return result;
        }
        /// <summary>
        /// Get Currency Types Available for a group of Banks by bankId
        /// supports pagination
        /// </summary>
        /// <param name="bankIds"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<BankAvilableCurrencyType> GetCurrencyTypesAvailableForBanks(IEnumerable<int> bankIds,
            int page = 1, int pageSize = 10)
        {
            var result = Context.Set<BankAvilableCurrencyType>()
                .Where(x => bankIds.Any(b => b == x.BankId))
                .Skip((page - 1)*pageSize)
                .Take(pageSize)
                .AsEnumerable();
            return result;
        }
    }
}