namespace CTDS.CaseManagement.Contracts.Dto
{
    using System;

    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
