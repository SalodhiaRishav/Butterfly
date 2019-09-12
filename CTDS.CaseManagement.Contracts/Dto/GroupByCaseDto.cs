namespace CTDS.CaseManagement.Contracts.Dto
{
    public class GroupByCaseDTO
    {
        public int InProcessHigh { get; set; }
        public int InProcessMed { get; set; }
        public int InProcessLow { get; set; }
        public int CloseHigh { get; set; }
        public int CloseMed { get; set; }
        public int CloseLow { get; set; }
    }
}
