using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepository
    {
        User Get(string username, string password);
    }
}
