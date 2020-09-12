using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _dotnetSandBox.Dtos.Character;
using _dotnetSandBox.Models;
using _dotnetSandBox.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace _dotnetSandBox.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;

        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_characterService.GetAllCharacters().Result);
        }

        [HttpGet("GetSingle/{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            return Ok( _characterService.GetCharacterById(id).Result);
        }

        [HttpPost("AddCharacter")]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
            return Ok(_characterService.AddCharacter(newCharacter).Result);
            
        }
    }
}