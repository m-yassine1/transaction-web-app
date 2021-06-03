using System.Collections.Generic;
using Transactions.Server.Service.Model;

namespace Transactions.Server.Service
{
    public interface IAccountService
    {
        public void CreateAccount(AccountDto accountDto);
        public void UpdateAccount(long id, AccountDto accountDto);
        public void DeleteAccount(long id);
        public AccountDto GetAccount(long id);
        public ICollection<AccountDto> GetAccounts();
    }
}
