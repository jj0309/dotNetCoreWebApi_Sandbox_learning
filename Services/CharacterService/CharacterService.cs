using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _dotnetSandBox.Dtos.Character;
using _dotnetSandBox.Models;
using AutoMapper;

namespace _dotnetSandBox.Services.CharacterService
{

    public class CharacterService : ICharacterService
    {
        private static List<Character> characters = new List<Character>(){
            new Character(),
            new Character {id = 1,name = "peter"}
        };
        private readonly IMapper _mapper;
        public CharacterService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            character.id = characters.Max(c=>c.id)+1;
            characters.Add(character);
            serviceResponse.data = (characters.Select(c=>_mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            serviceResponse.data = (characters.Select(c=>_mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            serviceResponse.data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c => c.id == id));
            return serviceResponse;
        }
    }
}