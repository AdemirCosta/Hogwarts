using System;

namespace Core.Entities
{
    public class User
    {
        public Guid Id { get; private set; }

        public string Username { get; private set; }

        public string Password { get; private set; }

        public User()
        {
        }

        public User(string username, string password)
        {
            Id = Guid.NewGuid();
            Username = username;
            Password = password;
        }
    }
}
