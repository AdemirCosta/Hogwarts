using Core.Entities;
using System.Collections.Generic;

namespace Test.Settings.Seeds
{
    public static class UserSeed
    {
        public static List<User> Seeds()
        {
            return new List<User>
            {
                new User("Ademir", "123")
            };
        }
    }
}
