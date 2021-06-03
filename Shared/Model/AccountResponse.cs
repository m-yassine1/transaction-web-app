namespace Transactions.Shared.Model
{
    public class AccountResponse
    {
        public long Id { set; get; }
        public long AccountNumber { set; get; }
        public string Iban { set; get; }
        public string BankName { set; get; }
        public string Currency { set; get; }
    }
}
