using System;
using System.Collections.Generic;

namespace UnitOfWorkBanking.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public DateTime DateOfCreation { get; set; }
    }
}