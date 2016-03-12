using System;
using System.Collections.Generic;
using System.Linq;
using BankingUoW.Interfaces;
using UnitOfWorkBanking.DbContext;
using UnitOfWorkBanking.Entities;

namespace BankingUoW.Repository
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        //Pass DbContext to base class
        public ClientRepository(ApplicationDbContext context) :base(context)
        {}
        /// <summary>
        /// Get clients for a specific Bank
        /// supports pagination
        /// </summary>
        /// <param name="bankId"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Client> GetClientsByBank(int bankId, int page = 1, int pageSize = 10)
        {
            IEnumerable<Client> result = null;
            var bankAccounts = Context.Set<BankAccount>()
                .Where(x => x.BankId == bankId)
                .Select(x => x.ClientId);
            result = Context.Set<Client>()
                .Where(x => bankAccounts.Any(y => y == x.ClientId))
                .Skip((page - 1)*pageSize)
                .Take(pageSize)
                .AsEnumerable();
            return result;
        }
        /// <summary>
        /// Get clients registered in a specific DateTime Range
        /// Supports pagination
        /// If start or end is null returns all clients registered before/after a date
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<Client> GetClientsRegisteredInRange(DateTime? start, DateTime? end, int page = 1,
            int pageSize = 10)
        {
            IEnumerable<Client> result = null;
            if (start != null)
            {
                if (end != null)
                {
                    result = Context.Set<Client>()
                        .Where(x => x.DateOfCreation >= start && x.DateOfCreation <= end)
                        .Skip((page - 1)*pageSize)
                        .Take(pageSize)
                        .AsEnumerable();
                    return result;
                }
                result = Context.Set<Client>()
                    .Where(x => x.DateOfCreation >= start)
                    .Skip((page - 1)*pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
                return result;
            }
            if (end!=null)
            {
                result = Context.Set<Client>()
                    .Where(x => x.DateOfCreation <= end)
                    .Skip((page - 1)*pageSize)
                    .Take(pageSize)
                    .AsEnumerable();
                return result;
            }
            result = Context.Set<Client>().AsEnumerable();
            return result;
        } 
    }
}