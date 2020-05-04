using CustomORM;

namespace CustomIdentity.Data
{
    public class ApplicationDbContext : ContextBase
    {
        public Repository<ApplicationUser> Users { get; set; }

        public ApplicationDbContext() : base("DefaultConnection")
        {
        }
    }
}
