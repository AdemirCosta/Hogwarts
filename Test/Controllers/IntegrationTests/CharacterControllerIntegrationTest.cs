using Api.Controllers;
using Api.Models.Dtos;
using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Data.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Settings.Factories;
using Test.Settings.Seeds;

namespace Test.Controllers.IntegrationTests
{
    public class CharacterControllerIntegrationTest
    {
        public CharacterRepository _characterRepository;
        public Mock<IHouseRepository> _mockHouseRepository;

        public CharacterService _characterService;

        public CharacterController _characterController;
        public HogwartsContext _context;

        [SetUp]
        public void Setup()
        {
            _context = DbContextFactory.Create();

            _characterRepository = new CharacterRepository(_context);
            _mockHouseRepository = new Mock<IHouseRepository>();

            _mockHouseRepository.Setup(h => h.CheckHouseExistence(It.IsAny<string>())).Returns(Task.FromResult(true));

            _characterService = new CharacterService(_characterRepository, _mockHouseRepository.Object);

            _characterController = new CharacterController(_characterService, AutoMapperFactory.Create());
        }

        [Test]
        public void GetTest()
        {
            var result = _characterController.Get(CharacterSeed.Seeds().FirstOrDefault().Id);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(CharacterSeed.Seeds().FirstOrDefault().Id, ((Character)((OkObjectResult)result.Result).Value).Id);
        }

        [Test]
        public void GetMultipleTest()
        {
            var result = _characterController.Get(new List<Guid> { CharacterSeed.Seeds().FirstOrDefault().Id });

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"), ((List<Character>)((OkObjectResult)result.Result).Value).FirstOrDefault().Id);
        }

        [Test]
        public void GetByHouseIdTest()
        {
            var result = _characterController.GetByHouseId("1");

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"), ((List<Character>)((OkObjectResult)result.Result).Value).FirstOrDefault().Id);
        }

        [Test]
        public void DeleteTest()
        {
            _characterController.Delete(CharacterSeed.Seeds().FirstOrDefault().Id);

            Assert.AreEqual(CharacterSeed.Seeds().Count - 1, _context.Characters.Count());
        }

        //[Test]
        //public void PostUpdateTest()
        //{

        //    CharacterDto characterDto = new CharacterDto();
        //    characterDto.Id = CharacterSeed.Seeds().FirstOrDefault().Id;
        //    characterDto.Name = CharacterSeed.Seeds().FirstOrDefault().Name + "UPDATE";
        //    characterDto.Role = CharacterSeed.Seeds().FirstOrDefault().Role + "UPDATE";
        //    characterDto.School = CharacterSeed.Seeds().FirstOrDefault().School + "UPDATE";
        //    characterDto.Patronus = CharacterSeed.Seeds().FirstOrDefault().Patronus + "UPDATE";

        //    var result = _characterController.Post(characterDto);
        //    var character = (Character)((OkObjectResult)result).Value;

        //    Assert.AreEqual(characterDto.Name, character.Name);
        //    Assert.AreEqual(characterDto.Role, character.Role);
        //    Assert.AreEqual(characterDto.School, character.School);
        //    Assert.AreEqual(characterDto.Patronus, character.Patronus);
        //}

        [Test]
        public void PostTest()
        {
            //Add
            var characterDto = new CharacterDto
            {
                Name = "Hermione",
                Role = "student",
                HouseId = "1",
                School = "Hogwarts",
                Patronus = "otter"
            };

            var result = _characterController.Post(characterDto);
            var characterId = ((Character)((OkObjectResult)result).Value).Id;

            Assert.AreEqual(CharacterSeed.Seeds().Count + 1, _context.Characters.Count());

            //Update
            characterDto.Id = characterId;
            characterDto.Name = "Hermione2";
            characterDto.Role = "student2";
            characterDto.School = "Hogwarts2";
            characterDto.Patronus = "otter2";

            result = _characterController.Post(characterDto);
            var character = (Character)((OkObjectResult)result).Value;

            Assert.AreEqual(characterDto.Name, character.Name);
            Assert.AreEqual(characterDto.Role, character.Role);
            Assert.AreEqual(characterDto.School, character.School);
            Assert.AreEqual(characterDto.Patronus, character.Patronus);
        }

        [TearDown]
        public void TearDown()
        {
            _context.Database.EnsureDeleted();
        }
    }
}
