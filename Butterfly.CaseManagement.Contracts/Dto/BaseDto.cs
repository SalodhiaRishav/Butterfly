using System;

namespace Butterfly.CaseManagement.Contracts.Dto
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
