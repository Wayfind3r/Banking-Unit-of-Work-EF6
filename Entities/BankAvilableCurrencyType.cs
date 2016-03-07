using UnitOfWorkBanking.Enums;

namespace UnitOfWorkBanking.Entities
{
    public class BankAvilableCurrencyType
    {
        public int BankAvilableCurrencyTypeId { get; set; }
        public int BankId { get; set; }
        public virtual Bank Bank { get; set; }
        public CurrencyType CurrencyType { get; set; }
    }
}