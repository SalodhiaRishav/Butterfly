namespace CTDS.CaseManagement.Contracts.Dto
{
    using System.Collections.Generic;
    public class CaseDto : BaseDto
    {
        public int CaseId { get; set; }
        public ClientDto Client { get; set; }
        public CaseInformationDto CaseInformation { get; set; }
        public CaseStatusDto CaseStatus { get; set; }
        public NotesDto Notes { get; set; }
        public List<CaseReferenceDto> References { get; set; } 
    }
}
