using System.Linq;
using Socrat.Core.Entities;

namespace Socrat.DataProvider.Repos
{
    internal class UserRepository : UniversalRepository<User>
    {
        internal User GetUserByLogin(string login)
        {
            User _user = SocratEntities.Users.FirstOrDefault(x => x.Login == login);
            return _user;
        }
    }
}