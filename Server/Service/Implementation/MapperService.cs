using System.Collections.Generic;
using Transactions.Server.Repository;
using Transactions.Server.Service.Model;
using Transactions.Shared.Model;

namespace Transactions.Server.Service.Implementation
{
    public class MapperService : IMapperService
    {
        public AccountDto ToAccountDto(AccountRequest request)
        {
            return new AccountDto
            {
                AccountNumber = request.AccountNumber,
                BankName = request.BankName,
                Currency = request.Currency,
                Iban = request.Iban
            };
        }

        public AccountDto ToAccountDto(AccountEntity accountEntity)
        {
            return new AccountDto
            {
                Id = accountEntity.Id,
                AccountNumber = accountEntity.AccountNumber,
                BankName = accountEntity.BankName,
                Currency = accountEntity.Currency,
                Iban = accountEntity.Iban
            };
        }

        public AccountEntity ToAccountEntity(AccountDto accountDto)
        {
            return new AccountEntity
            {
                Id = accountDto.Id,
                AccountNumber = accountDto.AccountNumber,
                BankName = accountDto.BankName,
                Currency = accountDto.Currency,
                Iban = accountDto.Iban
            };
        }

        public AccountResponse ToAccountResponse(AccountDto accountDto)
        {
            return new AccountResponse
            {
                Id = accountDto.Id,
                AccountNumber = accountDto.AccountNumber,
                BankName = accountDto.BankName,
                Currency = accountDto.Currency,
                Iban = accountDto.Iban
            };
        }

        public ICollection<AccountDto> ToAccountDtos(ICollection<AccountEntity> accountEntities)
        {
            List<AccountDto> accounts = new();
            foreach(AccountEntity accountEntity in accountEntities)
            {
                accounts.Add(new AccountDto
                {
                    Id = accountEntity.Id,
                    AccountNumber = accountEntity.AccountNumber,
                    BankName = accountEntity.BankName,
                    Currency = accountEntity.Currency,
                    Iban = accountEntity.Iban
                });
            }

            return accounts;
        }

        public ICollection<AccountResponse> ToAccountsResponse(ICollection<AccountDto> accountDtos)
        {
            List<AccountResponse> accounts = new();
            foreach (AccountDto accountDto in accountDtos)
            {
                accounts.Add(new AccountResponse
                {
                    Id = accountDto.Id,
                    AccountNumber = accountDto.AccountNumber,
                    BankName = accountDto.BankName,
                    Currency = accountDto.Currency,
                    Iban = accountDto.Iban
                });
            }

            return accounts;
        }

        public BalanceDto ToBalanceDto(BalanceEntity balanceEntity)
        {
            return new BalanceDto
            {
                AccountNumber = balanceEntity.AccountNumber,
                Amount = balanceEntity.Amount,
                Date = balanceEntity.Date
            };
        }

        public BalanceResponse ToBalanceResponse(BalanceDto balanceDto)
        {
            return new BalanceResponse
            {
                Amount = balanceDto.Amount
            };
        }

        public TransactionEntity ToTransacstionEntity(TransactionDto transactionEntity)
        {
            return new TransactionEntity
            {
                Id = transactionEntity.Id,
                AccountNumber = transactionEntity.AccountNumber,
                Amount = transactionEntity.Amount,
                DateTime = transactionEntity.DateTime
            };
        }

        public TransactionDto ToTransactionDto(TransactionRequest request)
        {
            return new TransactionDto
            { 
                Amount = request.Amount,
                DateTime = request.DateTime
            };
        }

        public TransactionDto ToTransactionDto(TransactionEntity transactionEntity)
        {
            return new TransactionDto
            {
                Id = transactionEntity.Id,
                AccountNumber = transactionEntity.AccountNumber,
                Amount = transactionEntity.Amount,
                DateTime = transactionEntity.DateTime
            };
        }

        public TransactionResponse ToTransactionResponse(TransactionDto transactionDto)
        {
            return new TransactionResponse
            {
                Id = transactionDto.Id,
                Amount = transactionDto.Amount,
                DateTime = transactionDto.DateTime
            };
        }

        public ICollection<TransactionDto> ToTransactionsDto(ICollection<TransactionEntity> transactionEntities)
        {
            List<TransactionDto> transactions = new();
            foreach (TransactionEntity transactionEntity in transactionEntities)
            {
                transactions.Add(new TransactionDto
                {
                    Id = transactionEntity.Id,
                    AccountNumber = transactionEntity.AccountNumber,
                    Amount = transactionEntity.Amount,
                    DateTime = transactionEntity.DateTime
                });
            }

            return transactions;
        }
    }
}
