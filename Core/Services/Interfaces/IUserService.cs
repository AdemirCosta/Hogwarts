using Core.Entities;

namespace Core.Services
{
    public interface IUserService
    {
        User Get(string username, string password);
    }
}
