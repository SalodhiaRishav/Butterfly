namespace CTDS.CaseManagement.Contracts.Dto
{
    public class GroupByCaseDTO
    {
        public int NewHigh { get; set; }
        public int NewMed { get; set; }
        public int NewLow { get; set; }
        public int InProcessHigh { get; set; }
        public int InProcessMed { get; set; }
        public int InProcessLow { get; set; }
        public int CloseHigh { get; set; }
        public int CloseMed { get; set; }
        public int CloseLow { get; set; }
    }
}
