using Api.Controllers;
using Api.Models.Dtos;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Settings.Factories;
using Test.Settings.Seeds;

namespace Test.Controllers
{
    public class CharacterControllerTest
    {
        public Mock<ICharacterService> _characterService;

        public CharacterController _characterController;

        [SetUp]
        public void Setup()
        {
            _characterService = new Mock<ICharacterService>();

            _characterService.Setup(c => c.Get(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"))).Returns(CharacterSeed.Seeds().Where(c => c.Id == Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B")).FirstOrDefault());
            _characterService.Setup(c => c.Get(new List<Guid> { Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B") })).Returns(CharacterSeed.Seeds().Where(c => c.Id == Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B")).ToList());
            _characterService.Setup(c => c.GetByHouseId("1")).Returns(CharacterSeed.Seeds().Where(c => c.Id == Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B")).ToList());
            _characterService.Setup(c => c.Delete(It.IsAny<Guid>()));

            _characterController = new CharacterController(_characterService.Object, AutoMapperFactory.Create());
        }

        [Test]
        public void GetTest()
        {
            var characterDto = new CharacterDto
            {
                Id = Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B")
            };

            var result = _characterController.Get(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"));

            Assert.AreEqual(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"), ((Character)((OkObjectResult)result.Result).Value).Id);
        }

        [Test]
        public void GetMultipleTest()
        {
            var result = _characterController.Get(new List<Guid> { Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B") });

            Assert.AreEqual(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"), ((List<Character>)((OkObjectResult)result.Result).Value).FirstOrDefault().Id);
        }

        [Test]
        public void GetByHouseIdTest()
        {
            var result = _characterController.GetByHouseId("1");

            Assert.AreEqual(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"), ((List<Character>)((OkObjectResult)result.Result).Value).FirstOrDefault().Id);
        }

        [Test]
        public void DeleteTest()
        {
            _characterController.Delete(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"));
        }

        [Test]
        public void PostTest()
        {
            var character = new CharacterDto
            {
                Name = "Harry",
                Role = "student",
                HouseId = "1",
                Patronus = "stag",
                School = "Hogwarts"
            };

            _characterController.Post(character);
        }
    }
}
