using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace Core.Services
{
    public class CharacterService : ICharacterService
    {
        public readonly ICharacterRepository _characterRepository;
        public readonly IHouseRepository _houseRepository;

        public CharacterService(ICharacterRepository characterRepository, IHouseRepository houseRepository)
        {
            _characterRepository = characterRepository;
            _houseRepository = houseRepository;
        }

        public Character Get(Guid id)
        {
            return _characterRepository.Get(id);
        }

        public List<Character> Get(List<Guid> ids)
        {
            return _characterRepository.Get(ids);
        }

        public List<Character> GetByHouseId(string houseId)
        {
            return _characterRepository.GetByHouseId(houseId);
        }


        public Character Update(Character character)
        {
            if (!character.Validate()) BadRequestException.Throw();

            if (!ValidateHouse(character.HouseId)) BadRequestException.Throw();

            if (character.Id == Guid.Empty)
            {
                character.SetId();
                return _characterRepository.Add(character);
            }
            else
            {
                var currentCharacter = _characterRepository.Get(character.Id);

                if (currentCharacter == null)
                {
                    BadRequestException.Throw();
                }

                currentCharacter.UpdateData(character);
                return _characterRepository.Update(currentCharacter);
            }
        }

        public void Delete(Guid id)
        {
            var character = _characterRepository.Get(id);

            if (character != null)
            {
                _characterRepository.Delete(character);
            }
        }

        public bool ValidateHouse(string houseId)
        {
            return _houseRepository.CheckHouseExistence(houseId).Result;
        }
    }
}
