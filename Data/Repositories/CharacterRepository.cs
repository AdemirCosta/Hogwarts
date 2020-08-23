using Core.Entities;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(HogwartsContext dbContext)
            : base(dbContext)
        {
        }

        public Character Add(Character character)
        {
            _dbContext.Characters.Add(character);
            _dbContext.SaveChanges();

            return character;
        }

        public Character Update(Character character)
        {
            _dbContext.Characters.Update(character);
            _dbContext.SaveChanges();

            return character;
        }

        public void Delete(Character character)
        {
            _dbContext.Characters.Remove(character);
            _dbContext.SaveChanges();
        }

        public Character Get(Guid id)
        {
            return _dbContext.Characters.FirstOrDefault(c => c.Id == id);
        }

        public List<Character> Get(List<Guid> ids)
        {            
            return _dbContext.Characters.Where(c => ids.Contains(c.Id)).ToList();
        }

        public List<Character> GetAll()
        {
            return _dbContext.Characters.ToList();
        }

        public List<Character> GetByHouseId(string houseId)
        {
            return _dbContext.Characters.Where(c => c.HouseId == houseId).ToList();
        }
    }
}
