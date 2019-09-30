namespace CTDS.CaseManagement.Contracts.Dto
{
    using System;

    using CTDS.CaseManagement.Contracts.Enums;

    public class CaseTableDto
    {
        public Guid Id { get; set; }
        public int CaseId { get; set; }
        public CaseStatusType Status { get; set; }
        public PriorityType Priority { get; set; }
        public DateTime CreatedOn { get; set; }
        public string Description { get; set; }
        public string Client { get; set; }
        public string Notes { get; set; }
    }
}
