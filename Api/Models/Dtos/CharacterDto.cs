using System;

namespace Api.Models.Dtos
{
    public class CharacterDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Role { get; set; }

        public string School { get; set; }

        public string HouseId { get; set; }

        public string Patronus { get; set; }
    }
}
