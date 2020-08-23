using Core.Entities;
using Core.Interfaces;

namespace Core.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public User Get(string username, string password)
        {
            return _userRepository.Get(username, password);
        }
    }
}