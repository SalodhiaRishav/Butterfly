namespace CTDS.Declarations.Contracts.DeclarationDTO
{
    using System;

    public class DeclarationTableDto
    {
        public Guid DeclarationId { get; set; }
        public String Status { get; set; } = "Processing";
        public String Procedure { get; set; } = "Import";
        public DateTime CreatedOn { get; set; }
        public String Country { get; set; } = "NO";
        public String MessageName { get; set; }
    }
}
