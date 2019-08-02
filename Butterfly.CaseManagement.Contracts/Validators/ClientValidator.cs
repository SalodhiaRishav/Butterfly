namespace Butterfly.CaseManagement.Contracts.Validators
{
    using Butterfly.CaseManagement.Contracts.Dto;
    using FluentValidation;

    public class ClientValidator : AbstractValidator<ClientDto>
    {
       public ClientValidator()
        {
            RuleFor(client => client.ClientIdentifier).CheckEmpty().CheckNull();
            RuleFor(client => client.IdentifierType).CheckEmpty().CheckNull();
            RuleFor(client => client.ClientIdentifier).CheckEmpty().CheckNull();
            RuleFor(client => client.ClientIdentifier).CheckEmpty().CheckNull();
            RuleFor(client => client.ClientIdentifier).CheckEmpty().CheckNull();

        }
    }
}
