namespace CTDS.Database.Models.Common
{
    using System;
    public class MasterData
    {
        public Guid Id { get; set; }
        public String Type { get; set; }
        public String Key { get; set; }
        public String Value { get; set; }
    }
}
