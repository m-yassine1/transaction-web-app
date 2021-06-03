using System;

namespace Transactions.Shared.Model
{
    public class TransactionResponse
    {
        public long Id { set; get; }
        public double Amount { set; get; }
        public DateTime DateTime { set; get; }
    }
}
