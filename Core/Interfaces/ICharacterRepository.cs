using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Interfaces
{
    public interface ICharacterRepository
    {
        Character Add(Character character);
        Character Update(Character character);
        void Delete(Character character);
        Character Get(Guid id);
        List<Character> Get(List<Guid> ids);
        List<Character> GetAll();
        List<Character> GetByHouseId(string houseId);
    }
}
