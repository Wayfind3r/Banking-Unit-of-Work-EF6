using System;
using System.Collections.Generic;
using System.Linq;
using BankingUoW.Interfaces;
using UnitOfWorkBanking.DbContext;
using UnitOfWorkBanking.Entities;
using UnitOfWorkBanking.Enums;

namespace BankingUoW.Repository
{
    public class BankRepository : Repository<Bank>, IBankRepository
    {
        //pass Context to base costructor
        public BankRepository(ApplicationDbContext context):base(context)
        {
            
        }
        //Get all Banks that allow work with a currency type
        public IEnumerable<Bank> GetBanksByAvailableCurrency(CurrencyType currency)
        {
            IEnumerable<Bank> result = null;
                result = Context.Set<BankAvilableCurrencyType>()
                    .Where(x => x.CurrencyType == currency)
                    .Select(x=>x.Bank).AsEnumerable();
            return result;
        }
        //Get all Banks that work with a collection for currencies
        public IEnumerable<Bank> GetBanksByAvailableCurrencies(HashSet<CurrencyType> currencies)
        {
            IEnumerable<Bank> result = null;
            var bankIds = new List<int>();
            foreach (var currency in currencies)
            {
                var bankIdsSet = Context.Set<BankAvilableCurrencyType>()
                    .Where(x => x.CurrencyType == currency)
                    .Select(x => x.BankId).ToList();
                bankIds = (bankIds.Count>0) ? bankIdsSet 
                    : bankIdsSet.Intersect(bankIds).ToList();
            }
            result = Context.Set<Bank>().Where(x => bankIds.Any(id => id == x.BankId));
                //result = Context.Set<Bank>()
                //    .Where(x => currencies.All(t => x.BankCurrencyTypes.Any(c => c.CurrencyType == t)))
                //    .AsEnumerable();
            return result;
        }
        /// <summary>
        /// Get all banks with specified address (ToLower exact match)
        /// </summary>
        /// <param name="address"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Bank> GetBanksByAddress(string address, int page = 1, int pageSize = 10)
        {
            var addressToLower = address.ToLower();
            IEnumerable<Bank> result = null;
            result = Context.Set<Bank>()
                .Where(x => x.Address.ToLower() == addressToLower)
                .Skip((page - 1)*pageSize)
                .Take(pageSize);
            return result;
        }
        /// <summary>
        /// Get all banks with Name containg a string (InvariantCultureIgnoreCase, Index Of)
        /// </summary>
        /// <param name="name"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Bank> GetBanksByName(string name, int page = 1, int pageSize = 10)
        {
            IEnumerable<Bank> result = null;
            result = Context.Set<Bank>()
                .Where(x => x.Name.IndexOf(name, StringComparison.InvariantCultureIgnoreCase)!=-1)
                .Skip((page - 1)*pageSize)
                .Take(pageSize);
            return result;
        } 
    }
}