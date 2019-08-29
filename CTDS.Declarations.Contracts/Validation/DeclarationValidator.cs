namespace CTDS.Declarations.Contracts.Validation
{
    using CTDS.Declarations.Contracts.DeclarationDTO;

    using FluentValidation;
    public class DeclarationValidator : AbstractValidator<DeclarationDto>
    {
        public DeclarationValidator()
        {
            RuleFor(x => x.ConsignorPostalCode).Matches(@"^([0-9]*)$").WithMessage("Postal Code Should be a Positive integer");
            RuleFor(x => x.Amount).Matches(@"^[0-9]+(\.[0-9]+)?$").WithMessage("Amount Should be a Positive Number");
            RuleFor(x => x.ConsigneeCity).Matches(@"^[a-zA-z]+$").WithMessage("City Name should have alphabets only");
            RuleFor(x => x.ConsigneePostalCode).Matches(@"^[0-9]+$").WithMessage("Postal Code should a positive integer");
            RuleFor(x => x.ConsignorPostalCode).Matches(@"^[0-9]+$").WithMessage("Postal Code should a positive integer");
            RuleFor(x => x.DeclarantPostalCode).Matches(@"^[0-9]+$").WithMessage("Postal Code should be positive integer");
           
        }
    }
}
