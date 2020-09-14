using System.Collections.Generic;
using System.Threading.Tasks;
using _dotnetSandBox.Dtos.Character;
using _dotnetSandBox.Models;

namespace _dotnetSandBox.Services.CharacterService
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters(int userId);
         Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id);
         Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter);
         Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter);
         Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id);
    }
}