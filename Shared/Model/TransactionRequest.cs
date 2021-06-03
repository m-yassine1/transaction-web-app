using System;

namespace Transactions.Shared.Model
{
    public class TransactionRequest
    {
        public double Amount { set; get; }
        public DateTime DateTime { set; get; }
    }
}
