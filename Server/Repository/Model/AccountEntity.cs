using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transactions.Server.Repository
{
    public class AccountEntity
    {
        [Key]
        public long Id { set; get; }
        [Column(name:"account_number")]
        public long AccountNumber { set; get; }
        public string Iban { set; get; }
        [Column(name: "bank_name")]
        public string BankName { set; get; }
        public string Currency { set; get; }
    }
}
