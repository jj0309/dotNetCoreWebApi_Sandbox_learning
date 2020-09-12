using _dotnetSandBox.Dtos.Character;
using _dotnetSandBox.Models;
using AutoMapper;

namespace _dotnetSandBox
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile(){
            CreateMap<Character,GetCharacterDto>();
            CreateMap<AddCharacterDto,Character>();
        }
    }
}