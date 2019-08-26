namespace CTDS.Database.Models.Declarations
{
    using System;
    public class ReferenceTable
    {
        public Guid ReferenceId { get; set; }
        public string Type { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Reference { get; set; }
        public Guid DeclarationId { get; set; }
    }
}
