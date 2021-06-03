using System;
using FluentValidation;
using Transactions.Shared.Model;

namespace Transactions.Client.Validator
{
    public class TransactionRequestValidator : AbstractValidator<TransactionRequest>
    {
        public TransactionRequestValidator()
        {
            RuleFor(transactionRequest => transactionRequest.Amount).NotEmpty().GreaterThan(0);
            RuleFor(transactionRequest => transactionRequest.DateTime).NotEmpty().LessThanOrEqualTo(DateTime.Now);
        }
    }
}
