namespace CTDS.Database.Models.Authentication
{
    using System.Collections.Generic;

    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
        public virtual ICollection<Token> UserTokens { get; set; }

    }
}
