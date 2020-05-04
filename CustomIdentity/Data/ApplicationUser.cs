using CustomORM;

namespace CustomIdentity.Data
{
    public class ApplicationUser : IUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        [Column("NormalizedUsername")]
        public string NormalizedUserName { get; set; }

        public string Password { get; set; }
    }
}
