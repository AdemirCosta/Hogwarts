using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Api.Models.Dtos;
using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
            return Ok(_characterService.Get(id));
        }

        [HttpGet]
        [Authorize]
        public ActionResult<List<Character>> Get([FromQuery] List<Guid> ids)
        {
            return Ok(_characterService.Get(ids));
        }

        [HttpGet("byHouse/{houseId}")]
        [Authorize]
        public ActionResult<List<Character>> GetByHouseId(string houseId)
        {
            return Ok(_characterService.GetByHouseId(houseId));
        }

        [HttpPost]
        [Authorize]
        public ActionResult Post([FromBody] CharacterDto characterDto)
        {
            return Ok(_characterService.Update(_mapper.Map<Character>(characterDto)));
        }

        [HttpPost("delete/{id}")]
        public ActionResult Delete(Guid id)
        {
            _characterService.Delete(id);
            return Ok();
        }
    }
}
