namespace CTDS.Declarations.Contracts.DeclarationDTO
{
    using System.Collections.Generic;
    public class DeclarationData
    {
        public DeclarationDto Declaration { get; set; }
        public IEnumerable<ReferenceDto> ReferenceData { get; set; }
    }
}
