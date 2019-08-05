namespace Butterfly.CaseManagement.Contracts.Dto
{
    using System.Collections.Generic;
    public class CaseDto : BaseDto
    {
        public ClientDto Client { get; set; }
        public CaseInformationDto CaseInformation { get; set; }
        public CaseStatusDto CaseStatus { get; set; }
        public NotesDto Notes { get; set; }
        public List<CaseReferenceDto> References { get; set; } 
    }
}
