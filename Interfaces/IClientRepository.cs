using System;
using System.Collections.Generic;
using UnitOfWorkBanking.Entities;

namespace BankingUoW.Interfaces
{
    public interface IClientRepository
    {
        IEnumerable<Client> GetClientsByBank(int bankId, int page = 1, int pageSize = 10);
        IEnumerable<Client> GetClientsRegisteredInRange(DateTime? start, DateTime? end, int page = 1, int pageSize = 10);
    }
}