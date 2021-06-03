using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using Transactions.Server.Repository;
using Transactions.Server.Service.Model;

namespace Transactions.Server.Service.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly TransactionContext _transactionContext;
        private readonly IMapperService _mapperService;
        private readonly ILogger<AccountService> _logger;

        public AccountService(TransactionContext transactionContext,
            IMapperService mapperService,
            ILogger<AccountService> logger)
        {
            _mapperService = mapperService;
            _transactionContext = transactionContext;
            _logger = logger;
        }

        public void CreateAccount(AccountDto accountDto)
        {
            if(_transactionContext.Accounts.Where(a => a.AccountNumber == accountDto.AccountNumber || a.Iban == accountDto.Iban).Any())
            {
                throw new Exception($"Account number {accountDto.AccountNumber} or iban {accountDto.Iban} already exists");
            }

            _transactionContext.Add(_mapperService.ToAccountEntity(accountDto));
        }

        public void DeleteAccount(long id)
        {
            if (!_transactionContext.Accounts.Where(a => a.Id == id).Any())
            {
                throw new Exception($"Account id {id} does not exist");
            }

            _transactionContext.Accounts.Remove(_transactionContext.Accounts.Where(a => a.Id == id).First());
        }

        public AccountDto GetAccount(long id)
        {
            if (!_transactionContext.Accounts.Where(a => a.Id == id).Any())
            {
                throw new Exception($"Account id {id} does not exist");
            }

            return _mapperService.ToAccountDto(_transactionContext.Accounts.Where(a => a.Id == id).First());
        }

        public ICollection<AccountDto> GetAccounts()
        {
            return _mapperService.ToAccountDtos(_transactionContext.Accounts.ToList());
        }

        public void UpdateAccount(long id, AccountDto accountDto)
        {
            if (_transactionContext.Accounts.Where(a => a.Id == id).Any())
            {
                throw new Exception($"Account id {id} does not exist");
            }

            if (_transactionContext.Accounts.Where(a => a.AccountNumber == accountDto.AccountNumber || a.Iban == accountDto.Iban).Any())
            {
                throw new Exception($"Account number {accountDto.AccountNumber} or iban {accountDto.Iban} already exists");
            }


            AccountEntity accountEntity = _mapperService.ToAccountEntity(accountDto);
            accountEntity.Id = id;
            _transactionContext.Accounts.Update(accountEntity);
        }
    }
}
