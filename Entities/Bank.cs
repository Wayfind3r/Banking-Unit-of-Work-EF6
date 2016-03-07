using System;
using System.Collections.Generic;

namespace UnitOfWorkBanking.Entities
{
    public class Bank
    {
        public int BankId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateOfCreation { get; set; }
        public virtual ICollection<BankAccount> BankAccounts { get; set; }
        public virtual ICollection<BankAvilableCurrencyType> BankCurrencyTypes { get; set; }
    }
}