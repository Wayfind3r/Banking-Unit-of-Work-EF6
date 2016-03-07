using UnitOfWorkBanking.Enums;

namespace UnitOfWorkBanking.Entities
{
    public class Transfer
    {
        public int TransferId { get; set; }
        public int BankAccountId { get; set; }
        public virtual BankAccount BankAccount { get; set; }
        public int TargetBankAccountId { get; set; }
        public CurrencyType CurrencyType { get; set; }
        public decimal Amount { get; set; }

        public TransferStatus TransferStatus { get; set; }
    }
}