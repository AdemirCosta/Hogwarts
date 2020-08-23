using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models.Dtos;
using Api.Settings;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    public class TokenController : Controller
    {
        public IUserService _userService;

        public TokenController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserDto userDto)
        {
            var user = _userService.Get(userDto.Username, userDto.Password);

            if (user == null)
                return NotFound(new { message = "Username or Password is incorrect" });

            var token = TokenProvider.GenerateToken(user);

            return token;
        }
    }
}
