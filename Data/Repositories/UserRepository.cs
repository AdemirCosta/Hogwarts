using Core.Entities;
using Core.Interfaces;
using System.Linq;

namespace Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(HogwartsContext dbContext)
            : base(dbContext)
        {
        }

        public User Get(string username, string password)
        {
            return _dbContext.Users.Where(u => u.Username == username && u.Password == password).FirstOrDefault();
        }
    }
}
