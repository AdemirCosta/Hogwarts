using Core.Interfaces;
using Core.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Test.Settings.Seeds;

namespace Test.Services
{
    public class UserServiceTest
    {
        public Mock<IUserRepository> _mockUserRepository;

        public UserService _userService;

        [SetUp]
        public void Setup()
        {
            _mockUserRepository = new Mock<IUserRepository>();

            _mockUserRepository.Setup(c => c.Get("Ademir", "123")).Returns(UserSeed.Seeds().FirstOrDefault());

            _userService = new UserService(_mockUserRepository.Object);
        }

        [Test]
        public void GetTest()
        {
            var user = _userService.Get("Ademir", "123");

            Assert.AreEqual("Ademir", user.Username);
        }
    }
}
