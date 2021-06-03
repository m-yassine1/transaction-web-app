using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using Transactions.Server.Repository;
using Transactions.Server.Service.Model;

namespace Transactions.Server.Service.Implementation
{
    public class BalanceService : IBalanceService
    {
        private readonly TransactionContext _transactionContext;
        private readonly IMapperService _mapperService;
        private readonly ILogger<BalanceService> _logger;

        public BalanceService(TransactionContext transactionContext,
            IMapperService mapperService,
            ILogger<BalanceService> logger)
        {
            _mapperService = mapperService;
            _transactionContext = transactionContext;
            _logger = logger;
        }

        public BalanceDto GetBalance(long accountNumber, DateTime date)
        {
            return _mapperService.ToBalanceDto(_transactionContext.Balances.Where(b => b.Date == date.Date && b.AccountNumber == accountNumber).First());
        }

        public void UpdateBalance(long accountNumber, DateTime date)
        {
            BalanceEntity balanceEntity = new BalanceEntity
            {
                AccountNumber = accountNumber,
                Date = date.Date,
                Amount = FetchAmount(accountNumber, date)
            };

            if (_transactionContext.Balances.Where(b => b.Date == date.Date && b.AccountNumber == accountNumber).Any())
            {
                _transactionContext.Balances.Update(balanceEntity);
            } else {
                _transactionContext.Balances.Add(balanceEntity);
            }
        }

        private double FetchAmount(long accountNumber, DateTime date)
        {
            return _transactionContext.Transactions.Where(t => t.DateTime == date.Date && t.AccountNumber == accountNumber).Sum(b => b.Amount);
        }
    }
}
