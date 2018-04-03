using System;
using FluentValidation;
using FluentValidation.Validators;
using MyHouseAPI.Model.Money;
using MyHouseAPI.Validation.Authorization;

namespace MyHouseAPI.Validation.Money
{
    public abstract class TransactionDetailsValidator<T> : AbstractValidator<T> where T : TransactionDetails
    {
        public TransactionDetailsValidator()
        {
            RuleFor(x => x.Creditor)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Debtor)
                .NotEmpty()
                .GreaterThan(0);

            RuleFor(x => x.Date)
                .NotEmpty()
                .GreaterThan(DateTime.MinValue);

            RuleFor(x => x.Gross)
                .NotEmpty()
                .SetValidator(new ScalePrecisionValidator(2, 19));

            RuleFor(x => x.Reference)
                .MaximumLength(200);
        }
    }

    public class TransactionValidator<T> : TransactionDetailsValidator<T> where T : Transaction
    {
        public TransactionValidator()
        {
            RuleFor(x => x.TransactionId)
                .NotEmpty()
                .GreaterThan(0);
        }
    }

    public class TransactionInsertRequestValidator : TransactionDetailsValidator<TransactionInsertRequest>
    {
        public TransactionInsertRequestValidator()
        {
            RuleFor(x => x.EnteredBy)
                .NotEmpty()
                .GreaterThan(0);
        }
    }
}
