namespace CustomIdentity.Data
{
    public interface IUser
    {
        int Id { get; set; }

        string Username { get; set; }

        string NormalizedUserName { get; set; }

        string Password { get; set; }
    }
}
