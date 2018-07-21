using AutoMapper;
using Tavern.Domain.Characters;
using Tavern.Repository.Characters.Models;

namespace Tavern.Repository.Characters.Profiles
{
    public class CharacterProfile : Profile
    {
	    public CharacterProfile()
	    {
		    CreateMap<Character, CharacterModel>();
		    CreateMap<CharacterModel, Character>();
	    }
    }
}
