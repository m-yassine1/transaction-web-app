using System;
using System.Collections.Generic;
using Transactions.Server.Service.Model;

namespace Transactions.Server.Service
{
    public interface ITransactionService
    {
        public void CreateTransaction(TransactionDto transactionDto);
        public void UpdateTransaction(long id, TransactionDto transactionDto);
        public void DeleteTransaction(long id);
        public TransactionDto GetTransaction(long id);
        public ICollection<TransactionDto> GetTransaction(long accountNumber, DateTime date);
        ICollection<TransactionDto> GetTransactions(long accountNumber);
    }
}
