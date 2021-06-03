using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transactions.Server.Repository
{
    public class TransactionEntity
    {
        [Key]
        public long Id { set; get; }
        [ForeignKey("Account")]
        public long AccountNumber { set; get; }
        public double Amount { set; get; }
        public DateTime DateTime { set; get; }
    }
}
