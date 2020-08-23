using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities
{
    public class Character
    {
        public Guid Id { get; private set; }

        public string Name { get; private set; }

        public string Role { get; private set; }

        public string School { get; private set; }

        public string HouseId { get; private set; }

        public string Patronus { get; private set; }

        public Character()
        {
        }

        public Character(Guid id, string name, string role, string school, string houseId, string patronus)
        {
            Id = id;
            Name = name;
            Role = role;
            School = school;
            HouseId = houseId;
            Patronus = patronus;
        }
      

        public bool Validate()
        {
            return Name != string.Empty
                && Role != string.Empty
                && School != string.Empty
                && HouseId != string.Empty
                && Patronus != string.Empty;
        }

        public void SetId()
        {
            if (Id == Guid.Empty)
                Id = Guid.NewGuid();
        }

        public void UpdateData(Character character)
        {
            Name = character.Name;
            Role = character.Role;
            School = character.School;
            HouseId = character.HouseId;
            Patronus = character.Patronus;
        }
    }
}
