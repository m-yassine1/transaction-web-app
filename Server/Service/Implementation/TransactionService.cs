using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Transactions.Server.Repository;
using Transactions.Server.Service.Model;

namespace Transactions.Server.Service.Implementation
{
    public class TransactionService : ITransactionService
    {
        private readonly TransactionContext _transactionContext;
        private readonly IMapperService _mapperService;
        private readonly IBalanceService _balanceService;
        private readonly ILogger<TransactionService> _logger;

        public TransactionService(TransactionContext transactionContext,
            IBalanceService balanceService,
            IMapperService mapperService,
            ILogger<TransactionService> logger)
        {
            _balanceService = balanceService;
            _mapperService = mapperService;
            _transactionContext = transactionContext;
            _logger = logger;
        }

        public void CreateTransaction(TransactionDto transactionDto)
        {
            _transactionContext.Transactions.Add(_mapperService.ToTransacstionEntity(transactionDto));
            _balanceService.UpdateBalance(transactionDto.AccountNumber, transactionDto.DateTime);
        }

        public void DeleteTransaction(long id)
        {
            if (!_transactionContext.Transactions.Where(a => a.Id == id).Any())
            {
                throw new Exception($"Transaction id {id} does not exist");
            }
            
            TransactionDto transactionDto = GetTransaction(id);
            _transactionContext.Transactions.Remove(_transactionContext.Transactions.Where(a => a.Id == id).First());
            _balanceService.UpdateBalance(transactionDto.AccountNumber, transactionDto.DateTime);
        }

        public TransactionDto GetTransaction(long id)
        {
            if (!_transactionContext.Transactions.Where(a => a.Id == id).Any())
            {
                throw new Exception($"Transaction id {id} does not exist");
            }

            return _mapperService.ToTransactionDto(_transactionContext.Transactions.Where(a => a.Id == id).First());
        }

        public ICollection<TransactionDto> GetTransaction(long accountNumber, DateTime date)
        {
            return _mapperService.ToTransactionsDto(_transactionContext.Transactions.Where(t => t.AccountNumber == accountNumber && t.DateTime == date).ToList());
        }

        public ICollection<TransactionDto> GetTransactions(long accountNumber)
        {
            return _mapperService.ToTransactionsDto(_transactionContext.Transactions.Where(t => t.AccountNumber == accountNumber).ToList());
        }

        public void UpdateTransaction(long id, TransactionDto transactionDto)
        {
            if (!_transactionContext.Transactions.Where(a => a.Id == id).Any())
            {
                throw new Exception($"Transaction id {id} does not exist");
            }

            TransactionEntity transactionEntity = _mapperService.ToTransacstionEntity(transactionDto);
            transactionEntity.Id = id;
            _transactionContext.Transactions.Update(transactionEntity);
            _balanceService.UpdateBalance(transactionDto.AccountNumber, transactionDto.DateTime);
        }
    }
}
