using System;
using Transactions.Server.Service.Model;

namespace Transactions.Server.Service
{
    public interface IBalanceService
    {
        public void UpdateBalance(long accountNumber, DateTime date);
        public BalanceDto GetBalance(long accountNumber, DateTime date);
    }
}
