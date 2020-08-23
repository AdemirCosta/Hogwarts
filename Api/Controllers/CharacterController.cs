using Api.Models.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Controllers
{
    [Route("api/characters")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        public ICharacterService _characterService;
        public IMapper _mapper;

        public CharacterController(ICharacterService characterService, IMapper mapper)
        {
            _characterService = characterService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        [Authorize]
        public ActionResult<Character> Get(Guid id)
        {
            var character = _characterService.Get(id);

            if (character != null)
                return Ok(character);
            else
                return NotFound();
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<Character>> Get([FromQuery] List<Guid> ids)
        {
            var characters = _characterService.Get(ids);

            if (characters != null && characters.Count() > 0)
                return Ok(characters);
            else
                return NotFound();
        }

        [HttpGet("byHouse/{houseId}")]
        [Authorize]
        public ActionResult<List<Character>> GetByHouseId(string houseId)
        {
            var characters = _characterService.GetByHouseId(houseId);

            if (characters != null && characters.Count() > 0)
                return Ok(characters);
            else
                return NotFound();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] CharacterDto characterDto)
        {
            try
            {
                return Ok(_characterService.Update(_mapper.Map<Character>(characterDto)));
            }
            catch(System.Web.Http.HttpResponseException exception)
            {
                return StatusCode((int)exception.Response.StatusCode);
            }
        }

        [HttpPost("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            if (_characterService.Delete(id))
                return Ok();
            else
                return NotFound();
        }
    }
}
