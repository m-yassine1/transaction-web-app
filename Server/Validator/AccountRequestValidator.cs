using FluentValidation;
using IbanNet;
using IbanNet.FluentValidation;
using Transactions.Shared.Model;

namespace Transactions.Client.Validator
{
    public class AccountRequestValidator : AbstractValidator<AccountRequest>
    {
        public AccountRequestValidator(IIbanValidator ibanValidator)
        {
            RuleFor(accountRequest => accountRequest.Iban).NotEmpty().Iban(ibanValidator);
            RuleFor(accountRequest => accountRequest.AccountNumber).NotEmpty();
            RuleFor(accountRequest => accountRequest.BankName).NotEmpty();
            RuleFor(accountRequest => accountRequest.Currency).NotEmpty();
        }
    }
}
