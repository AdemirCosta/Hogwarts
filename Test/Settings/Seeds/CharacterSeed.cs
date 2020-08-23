using Core.Entities;
using System;
using System.Collections.Generic;

namespace Test.Settings.Seeds
{
    public static class CharacterSeed
    {
        public static List<Character> Seeds()
        {
            return new List<Character>
            {
                new Character(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"), "Harry Potter", "student", "Hogwarts School of Witchcraft and Wizardry", "1", "stag")
            };
        }
    }
}
