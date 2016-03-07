using System;
using UnitOfWorkBanking.Enums;

namespace UnitOfWorkBanking.Entities
{
    public class BankAccount
    {
        public int BankAccountId { get; set; }
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public int ClientId { get; set; }
        public virtual Client Client { get; set; }
        public DateTime DateOfCreation { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public decimal Balance { get; set; }
    }
}