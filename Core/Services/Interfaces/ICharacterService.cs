using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Services
{
    public interface ICharacterService
    {
        Character Get(Guid id);
        List<Character> Get(List<Guid> ids);
        List<Character> GetByHouseId(string houseId);
        Character Update(Character character);
        void Delete(Guid id);
    }
}
