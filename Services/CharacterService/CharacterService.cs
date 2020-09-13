using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _dotnetSandBox.Dtos.Character;
using _dotnetSandBox.Models;
using _dotnetSandBox.Data;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace _dotnetSandBox.Services.CharacterService
{

    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        private readonly DataContext _context;

        //dependency injection of automapper and context
        public CharacterService(IMapper mapper, DataContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            Character character = _mapper.Map<Character>(newCharacter);
            await _context.Characters.AddAsync(character);

            //commit
            await _context.SaveChangesAsync();

            // context-> characters table -> select(lambda expression -> map to getcharacterDto each characters)
            serviceResponse.data = await _context.Characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToListAsync();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            try
            {
                // context -> chracters table -> find the first one it can (id)
                Character character = _context.Characters.FirstOrDefault(c=>c.id == id);
                // context -> characters table -> remove(character)
                _context.Characters.Remove(character);
                // commit database
                await _context.SaveChangesAsync();
                // context -> characters table ->select(lambda expression -> map to GetCharacterDto type) -> into a list
                serviceResponse.data = await _context.Characters.Select(c=>_mapper.Map<GetCharacterDto>(c)).ToListAsync();
            }
            catch (System.Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
        {
            ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            List<Character> dbCharacters = await _context.Characters.ToListAsync();
            serviceResponse.data = (dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c))).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            Character dbCharacter = await _context.Characters.FirstOrDefaultAsync(c=>c.id == id);
            serviceResponse.data = _mapper.Map<GetCharacterDto>(dbCharacter);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
            try
            {
                // context-> characters table -> select(lambda expression -> find by id)
                Character character = await _context.Characters.FirstOrDefaultAsync(c => c.id == updatedCharacter.id);
                character.name = updatedCharacter.name;
                character.hitpoints = updatedCharacter.hitpoints;
                character.strenght = updatedCharacter.strenght;
                character.defense = updatedCharacter.defense;
                character.intelligence = updatedCharacter.intelligence;
                character.playClass = updatedCharacter.playClass;

                // update 
                _context.Characters.Update(character);
                //save db
                await _context.SaveChangesAsync();

                serviceResponse.data = _mapper.Map<GetCharacterDto>(character);
            }
            catch (System.Exception ex)
            {
                serviceResponse.success = false;
                serviceResponse.message = ex.Message;
            }
            return serviceResponse;
        }
    }
}