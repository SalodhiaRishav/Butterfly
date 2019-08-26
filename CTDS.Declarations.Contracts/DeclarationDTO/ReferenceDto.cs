namespace CTDS.Declarations.Contracts.DeclarationDTO
{
    using System;
    public class ReferenceDto
    {
        public Guid ReferenceId { get; set; }
        public string Type { get; set; }
        public string InvoiceDate { get; set; }
        public string Reference { get; set; }
        public Guid DeclarationId { get; set; }
    }
}
