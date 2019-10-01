namespace CTDS.Declarations.Contracts.DeclarationDTO
{
    using System.Collections.Generic;
    public class FilterDeclarationsDto
    {
        public List<DeclarationDto> Declarations { get; set; }
        public int TotalCount { get; set; }
    }
}
