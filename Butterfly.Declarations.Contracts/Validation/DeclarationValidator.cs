using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Butterfly.Declarations.Contracts.Validation
{
    using FluentValidation;
    using Butterfly.Declarations.Contracts.DeclarationDTO;
    public class DeclarationValidator : AbstractValidator<DeclarationDto>
    {
        public DeclarationValidator()
        {
            RuleFor(x => x.ConsignorPostalCode).Matches(@"^([0-9]*)$").WithMessage("Postal Code Should a Positive Whole Number");
            RuleFor(x => x.Amount).NotEmpty().Matches(@"^[0-9]+(\.[0-9]+)?$").WithMessage("Amount Should a Positive Real Number");
            RuleFor(x => x.ConsigneeCity).Matches(@"^[a-zA-z]+$").WithMessage("City Name should have characters between a-z");
            RuleFor(x => x.ConsigneePostalCode).Matches(@"^[0-9]+$").WithMessage("Postal Code is a positive whole number");
            RuleFor(x => x.ConsignorPostalCode).Matches(@"^[0-9]+$").WithMessage("Postal Code is a positive whole number");
            RuleFor(x => x.DeclarantPostalCode).Matches(@"^[0-9]+$").WithMessage("Postal Code is positive whole number");
           
        }
    }
}
