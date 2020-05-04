namespace CustomIdentity.Data
{
    public class ApplicationUser : IUser
    {
        public int Id { get; set; }

        public string Username { get; set; }

        public string NormalizedUserName { get; set; }

        public string Password { get; set; }
    }
}
