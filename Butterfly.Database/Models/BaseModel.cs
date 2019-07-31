namespace Butterfly.Database.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class BaseModel
    {
        public Guid Id { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
    }
}
