using Core.Entities;
using Core.Interfaces;
using Core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Test.Settings.Seeds;

namespace Test.Services
{
    public class CharacterServiceTest
    {
        public Mock<ICharacterRepository> _mockCharacterRepository;
        public Mock<IHouseRepository> _mockHouseRepository;

        public CharacterService _characterService;

        [SetUp]
        public void Setup()
        {
            _mockCharacterRepository = new Mock<ICharacterRepository>();
            _mockHouseRepository = new Mock<IHouseRepository>();
                        
            _mockCharacterRepository.Setup(c => c.Get(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"))).Returns(CharacterSeed.Seeds().Where(c => c.Id == Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B")).FirstOrDefault());
            _mockCharacterRepository.Setup(c => c.Get(new List<Guid> { Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B") })).Returns(CharacterSeed.Seeds().Where(c => c.Id == Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B")).ToList());
            _mockCharacterRepository.Setup(c => c.GetByHouseId("1")).Returns(CharacterSeed.Seeds().Where(c => c.HouseId == "1").ToList());
            _mockCharacterRepository.Setup(c => c.Delete(It.IsAny<Character>()));
            _mockHouseRepository.Setup(h => h.CheckHouseExistence(It.IsAny<string>())).Returns(Task.FromResult(true));

            _characterService = new CharacterService(_mockCharacterRepository.Object, _mockHouseRepository.Object);
        }

        [Test]
        public void GetTest()
        {
            var character = _characterService.Get(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"));

            Assert.AreEqual(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"), character.Id);
        }

        [Test]
        public void GetMultiplesTest()
        {
            var characters = _characterService.Get(new List<Guid> { Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B") });

            Assert.AreEqual(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"), characters.FirstOrDefault().Id);
        }

        [Test]
        public void GetByHouseIdTest()
        {
            var characters = _characterService.GetByHouseId("1");

            foreach(var character in characters)
            {
                Assert.AreEqual("1", character.HouseId);
            }
        }

        [Test]
        public void DeleteTest()
        {
            _characterService.Delete(Guid.Parse("60386D0F-AE88-4627-A11C-D6D4B974173B"));
        }

        [Test]
        public void ValidateHouseTest()
        {
            _characterService.ValidateHouse("1");
        }
    }
}
