using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using _dotnetSandBox.Dtos.Character;
using _dotnetSandBox.Models;
using _dotnetSandBox.Services.CharacterService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _dotnetSandBox.Controllers
{
    
    [Authorize]//requires to be logged to make calls
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;

        }

        //[AllowAnonymous] // allows to get called without being logged
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            int userId = int.Parse(User.Claims.FirstOrDefault(c=>c.Type == ClaimTypes.NameIdentifier).Value);
            ServiceResponse<List<GetCharacterDto>> result = await _characterService.GetAllCharacters(userId);
            return Ok(result.data);
        }

        [HttpGet("GetSingle/{id}")]
        public async Task<IActionResult> GetSingle(int id)
        {
            ServiceResponse<GetCharacterDto> result = await _characterService.GetCharacterById(id);
            return Ok(result.data);
        }

        [HttpPost("AddCharacter")]
        public async Task<IActionResult> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> result = await _characterService.AddCharacter(newCharacter);
            return Ok(result.data);
        }

        [HttpPut("UpdateCharacter")]
        public async Task<IActionResult> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
           ServiceResponse<GetCharacterDto> response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.success)
                return Ok(response.data);
            return NotFound(response);   
        }

        [HttpDelete("DeleteCharacter/{id}")]
        public async Task<IActionResult> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> response = await _characterService.DeleteCharacter(id);
            if(response.success)
                return Ok(response.data);
            return NotFound(response);
        }
    }
}