using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transactions.Server.Repository
{
    public class BalanceEntity
    {
        [Column(TypeName = "DATE")]
        public DateTime Date{ set; get; }
        [Column(name: "account_number")]
        [ForeignKey("Account")]
        public long AccountNumber { set; get; }
        public double Amount { set; get; }

    }
}
