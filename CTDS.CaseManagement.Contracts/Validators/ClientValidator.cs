namespace CTDS.CaseManagement.Contracts.Validators
{
    using CTDS.CaseManagement.Contracts.Dto;

    using FluentValidation;

    public class ClientValidator : AbstractValidator<ClientDto>
    {
       public ClientValidator()
        {
            RuleFor(client => client.ClientIdentifier).CheckEmpty().CheckNull();
            RuleFor(client => client.Name).MaximumLength(30);
            RuleFor(client => client.Address).MaximumLength(100);
            RuleFor(client => client.PostalCode).MaximumLength(50);
            RuleFor(client => client.City).MaximumLength(50);
            RuleFor(client => client.Email).MaximumLength(50);
        }
    }
}
