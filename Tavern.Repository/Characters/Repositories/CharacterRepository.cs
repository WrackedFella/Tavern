using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Tavern.Domain.Characters;
using Tavern.Repository.Characters.Models;

namespace Tavern.Repository.Characters.Repositories
{
	public class CharacterRepository : RepositoryBase<Character, CharacterModel>
	{
		public CharacterRepository(DbContext context) : base(context)
		{
			Mapper.Initialize(x =>
			{
				x.CreateMap<Character, CharacterModel>();
				x.CreateMap<CharacterModel, Character>();
			});
		}
	}
}
