namespace Butterfly.Database.Models.CaseManagement
{
    using Butterfly.CaseManagement.Contracts.Enums;

    public class Client : BaseModel
    {
        public string  ClientIdentifier { get; set; }
        public IdentifierType IdentifierType { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public Country Country { get; set; }
        public string Email { get; set;}
        public Case Case { get; set; }
    }
}
