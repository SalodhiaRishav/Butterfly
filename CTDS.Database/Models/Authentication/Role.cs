namespace CTDS.Database.Models.Authentication
{
    using System.Collections.Generic;

    public class Role
    {
        public int Id { get; set; }
        public string RoleName { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
