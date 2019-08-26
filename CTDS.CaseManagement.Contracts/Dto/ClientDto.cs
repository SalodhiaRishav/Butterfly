namespace CTDS.CaseManagement.Contracts.Dto
{
    using System;

    using CTDS.CaseManagement.Contracts.Enums;
    

    public class ClientDto : BaseDto
    {
        public string ClientIdentifier { get; set; }
        public IdentifierType IdentifierType { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public Guid CaseId { get; set; }
    }
}
