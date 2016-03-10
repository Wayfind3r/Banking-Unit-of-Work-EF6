using System.Collections.Generic;
using UnitOfWorkBanking.Enums;
using System.Linq;
using UnitOfWorkBanking.DbContext;

namespace BankingUoW.Services
{
    public class CurrencyServices
    {
        /// <summary>
        /// Get a Sorted dictionary of KeyValuePair decimal CurrencyType
        /// where the Key is the sum of all transfers with that currencyType
        /// and Value is the CurrencyType
        /// </summary>
        /// <returns></returns>
        public SortedDictionary<decimal, CurrencyType> GetMostTransferedCurrencies()
        {
            var result = new SortedDictionary<decimal, CurrencyType>();
            using (var db = new ApplicationDbContext())
            {
                var dictionary = db.Transfers
                    .GroupBy(x => x.CurrencyType)
                    .Select(x => new
                    {
                        Key = x.Sum(y => y.Amount),
                        Value = x.Key
                    }).ToDictionary(x=>x.Key, x=>x.Value);
                result = new SortedDictionary<decimal, CurrencyType>(dictionary);
            }
            return result;
        }
        /// <summary>
        /// Get a Sorted dictionary of KeyValuePair decimal CurrencyType
        /// where the Key is the sum of all transfers with that currencyType
        /// and Value is the CurrencyType
        /// </summary>
        /// <param name="currencyTypes">currencies included in the query</param>
        /// <returns></returns>
        public SortedDictionary<decimal, CurrencyType> GetMostTransferedCurrenciesFrom(
            IEnumerable<CurrencyType> currencyTypes)
        {
            var result = new SortedDictionary<decimal, CurrencyType>();
            using (var db = new ApplicationDbContext())
            {
                var dictionary = db.Transfers
                    .Where(x=>currencyTypes.Any(y=>y==x.CurrencyType))
                    .GroupBy(x => x.CurrencyType)
                    .Select(x => new
                    {
                        Key = x.Sum(y => y.Amount),
                        Value = x.Key
                    }).ToDictionary(x => x.Key, x => x.Value);
                result = new SortedDictionary<decimal, CurrencyType>(dictionary);
            }
            return result;
        }
    }
}