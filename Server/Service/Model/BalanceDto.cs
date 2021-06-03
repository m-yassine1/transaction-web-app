using System;

namespace Transactions.Server.Service.Model
{
    public class BalanceDto
    {
        public DateTime Date { set; get; }
        public long AccountNumber { set; get; }
        public double Amount { set; get; }
    }
}
