using CustomORM;
using System.Linq;

namespace CustomIdentity.Data.CustomIdentity
{
    public static class CustomORMExtensions
    {
        public static IUser FindUserByName<TUser>(this Repository<TUser> repository, string username) where TUser : IUser
        {
            return repository.GetAll().FirstOrDefault(u => u.Username == username);
        }
    }
}
