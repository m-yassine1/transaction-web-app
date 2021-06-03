using System.Collections.Generic;
using Transactions.Server.Repository;
using Transactions.Server.Service.Model;
using Transactions.Shared.Model;

namespace Transactions.Server.Service
{
    public interface IMapperService
    {
        public AccountDto ToAccountDto(AccountRequest request);
        public AccountDto ToAccountDto(AccountEntity accountEntity);
        public ICollection<AccountDto> ToAccountDtos(ICollection<AccountEntity> accountEntities);
        public ICollection<AccountResponse> ToAccountsResponse(ICollection<AccountDto> accountDtos);
        public AccountResponse ToAccountResponse(AccountDto accountDto);
        public AccountEntity ToAccountEntity(AccountDto accountDto);
        public TransactionResponse ToTransactionResponse(TransactionDto transactionDto);
        public TransactionDto ToTransactionDto(TransactionRequest request);
        public TransactionDto ToTransactionDto(TransactionEntity transactionEntity);
        public TransactionEntity ToTransacstionEntity(TransactionDto transactionEntity);
        public BalanceResponse ToBalanceResponse(BalanceDto balanceDto);
        public BalanceDto ToBalanceDto(BalanceEntity balanceEntity);
        public ICollection<TransactionDto> ToTransactionsDto(ICollection<TransactionEntity> transactionEntities);
    }
}
