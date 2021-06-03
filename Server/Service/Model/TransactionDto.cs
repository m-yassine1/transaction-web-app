using System;

namespace Transactions.Server.Service.Model
{
    public class TransactionDto
    {
        public long Id { set; get; }
        public long AccountNumber { set; get; }
        public double Amount { set; get; }
        public DateTime DateTime { set; get; }
    }
}
